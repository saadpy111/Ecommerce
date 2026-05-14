using Basket.Application.Dtos;
using Basket.Application.Features.Basket.Commands.CreateShoppingCart;
using Basket.Application.Features.Basket.Commands.DeleteBasketByUserName;
using Basket.Application.Features.Basket.Queries.GetBasketByUserName;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
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
    }
}
