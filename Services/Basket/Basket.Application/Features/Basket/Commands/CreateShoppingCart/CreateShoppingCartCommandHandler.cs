using AutoMapper;
using Basket.Application.Dtos;
using Basket.Core.Entities;
using Basket.Core.Repositories;
using MediatR;

namespace Basket.Application.Features.Basket.Commands.CreateShoppingCart
{
    public class CreateShoppingCartCommandHandler : IRequestHandler<CreateShoppingCartCommand, ShoppingCartResponse>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public CreateShoppingCartCommandHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<ShoppingCartResponse> Handle(CreateShoppingCartCommand request, CancellationToken cancellationToken)
        {
            var shoppingCart = _mapper.Map<ShoppingCart>(request);
            var updatedCart = await _basketRepository.UpdateBasket(shoppingCart);
            var shoppingCartResponse = _mapper.Map<ShoppingCartResponse>(updatedCart);

            return shoppingCartResponse;
        }
    }
}
