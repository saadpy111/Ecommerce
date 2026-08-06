using AutoMapper;
using Basket.Application.Dtos;
using Basket.Application.Features.Basket.Commands.CreateShoppingCart;
using Basket.Application.Features.Basket.Commands.DeleteBasketByUserName;
using Basket.Application.Features.Basket.Queries.GetBasketByUserName;
using Basket.Core.Entities;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.Api.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;
        private readonly ILogger<BasketController> _logger;

        public BasketController(IMediator mediator ,IPublishEndpoint publishEndpoint , IMapper mapper , ILogger<BasketController> logger)
        {
            _mediator = mediator;
            _publishEndpoint = publishEndpoint;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("{userName}")]
        public async Task<ActionResult<GetBasketByUserNameQueryResponse>> GetBasket(string userName)
        {
            var query = new GetBasketByUserNameQueryRequest(userName);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCartResponse>> UpdateBasket([FromBody] CreateShoppingCartCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{userName}")]
        public async Task<ActionResult> DeleteBasket(string userName)
        {
            var command = new DeleteBasketByUserNameCommand(userName);
            await _mediator.Send(command);
            return NoContent();
        }


        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Checkout([FromBody] BasketCheckout basketCheckout)
        {
            //get basket by user name
            var query = new GetBasketByUserNameQueryRequest(basketCheckout.UserName);
            var basket = await _mediator.Send(query);

            if (basket == null)
            {
                return BadRequest();
            }

            var eventMsg = _mapper.Map<BasketCheckoutEvent>(basketCheckout);
            eventMsg.TotalPrice = basket.ShoppingCart.TotalPrice;
            await _publishEndpoint.Publish(eventMsg);

            _logger.LogInformation($"Basket Published for {basket.ShoppingCart.UserName}");
            //remove from basket
            var deletedcmd = new DeleteBasketByUserNameCommand(basketCheckout.UserName);
            await _mediator.Send(deletedcmd);
            return Accepted();
        }
    }
}
