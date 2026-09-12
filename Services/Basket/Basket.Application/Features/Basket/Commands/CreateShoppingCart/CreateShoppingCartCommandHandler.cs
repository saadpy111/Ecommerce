using AutoMapper;
using Basket.Application.Dtos;
using Basket.Application.GrpcServices;
using Basket.Core.Entities;
using Basket.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Basket.Application.Features.Basket.Commands.CreateShoppingCart
{
    public class CreateShoppingCartCommandHandler : IRequestHandler<CreateShoppingCartCommand, ShoppingCartResponse>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        private readonly DiscountGrpcService _discountGrpcService;
        private readonly ILogger<CreateShoppingCartCommandHandler> _logger;

        public CreateShoppingCartCommandHandler(IBasketRepository basketRepository, IMapper mapper , DiscountGrpcService discountGrpcService, ILogger<CreateShoppingCartCommandHandler> logger)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
            _discountGrpcService = discountGrpcService;
            _logger = logger;
        }

        public async Task<ShoppingCartResponse> Handle(CreateShoppingCartCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating/updating shopping cart for UserName: {UserName}", request.UserName);
            foreach (var item in request.Items)
            {
                var coupon = await _discountGrpcService.GetDiscount(item.ProductName);
                if (coupon != null)
                {
                    _logger.LogInformation("Applied coupon discount for Product: {ProductName}, Amount: {Amount}", item.ProductName, coupon.Amount);
                    item.Price -= coupon.Amount;
                }
            }
            var shoppingCart = _mapper.Map<ShoppingCart>(request);
            var updatedCart = await _basketRepository.UpdateBasket(shoppingCart);
            var shoppingCartResponse = _mapper.Map<ShoppingCartResponse>(updatedCart);

            _logger.LogInformation("Successfully updated shopping cart for UserName: {UserName}", request.UserName);
            return shoppingCartResponse;
        }
    }
}
