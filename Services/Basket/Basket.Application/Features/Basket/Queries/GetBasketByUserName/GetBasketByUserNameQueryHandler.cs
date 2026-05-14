using AutoMapper;
using Basket.Application.Dtos;
using Basket.Core.Repositories;
using MediatR;

namespace Basket.Application.Features.Basket.Queries.GetBasketByUserName
{
    public class GetBasketByUserNameQueryHandler : IRequestHandler<GetBasketByUserNameQueryRequest, GetBasketByUserNameQueryResponse>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public GetBasketByUserNameQueryHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<GetBasketByUserNameQueryResponse> Handle(GetBasketByUserNameQueryRequest request, CancellationToken cancellationToken)
        {
            var shoppingCart = await _basketRepository.GetBasket(request.UserName);
            
            
            if (shoppingCart == null)
            {
                return new GetBasketByUserNameQueryResponse
                {
                    ShoppingCart = new ShoppingCartResponse { UserName = request.UserName }
                };
            }

            var shoppingCartResponse = _mapper.Map<ShoppingCartResponse>(shoppingCart);

            return new GetBasketByUserNameQueryResponse
            {
                ShoppingCart = shoppingCartResponse
            };
        }
    }
}
