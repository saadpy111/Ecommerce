using AutoMapper;
using Basket.Application.Dtos;
using Basket.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Basket.Application.Features.Basket.Queries.GetBasketByUserName
{
    public class GetBasketByUserNameQueryHandler : IRequestHandler<GetBasketByUserNameQueryRequest, GetBasketByUserNameQueryResponse>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetBasketByUserNameQueryHandler> _logger;

        public GetBasketByUserNameQueryHandler(IBasketRepository basketRepository, IMapper mapper, ILogger<GetBasketByUserNameQueryHandler> logger)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetBasketByUserNameQueryResponse> Handle(GetBasketByUserNameQueryRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching shopping basket for UserName: {UserName}", request.UserName);
            var shoppingCart = await _basketRepository.GetBasket(request.UserName);
            
            if (shoppingCart == null)
            {
                _logger.LogInformation("No existing basket found for UserName: {UserName}, returning empty basket", request.UserName);
                return new GetBasketByUserNameQueryResponse
                {
                    ShoppingCart = new ShoppingCartResponse { UserName = request.UserName }
                };
            }

            var shoppingCartResponse = _mapper.Map<ShoppingCartResponse>(shoppingCart);
            _logger.LogInformation("Retrieved basket for UserName: {UserName} with {ItemCount} items", request.UserName, shoppingCartResponse.Items.Count);

            return new GetBasketByUserNameQueryResponse
            {
                ShoppingCart = shoppingCartResponse
            };
        }
    }
}
