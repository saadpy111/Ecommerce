using AutoMapper;
using Basket.Application.Dtos;
using Basket.Application.GrpcServices;
using Basket.Core.Entities;
using Basket.Core.Repositories;
using MediatR;

namespace Basket.Application.Features.Basket.Commands.CreateShoppingCart
{
    public class CreateShoppingCartCommandHandler : IRequestHandler<CreateShoppingCartCommand, ShoppingCartResponse>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        private readonly DiscountGrpcService _discountGrpcService;

        public CreateShoppingCartCommandHandler(IBasketRepository basketRepository, IMapper mapper , DiscountGrpcService discountGrpcService)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
            _discountGrpcService = discountGrpcService;
        }

        public async Task<ShoppingCartResponse> Handle(CreateShoppingCartCommand request, CancellationToken cancellationToken)
        {
            foreach (var item in request.Items)
            {
                var coupon = await _discountGrpcService.GetDiscount(item.ProductName);
                if (coupon != null)
                    item.Price -= coupon.Amount;
            }
            var shoppingCart = _mapper.Map<ShoppingCart>(request);
            var updatedCart = await _basketRepository.UpdateBasket(shoppingCart);
            var shoppingCartResponse = _mapper.Map<ShoppingCartResponse>(updatedCart);

            return shoppingCartResponse;
        }
    }
}
