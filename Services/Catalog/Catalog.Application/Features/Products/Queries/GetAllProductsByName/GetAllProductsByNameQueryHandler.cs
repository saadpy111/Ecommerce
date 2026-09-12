using AutoMapper;
using Catalog.Application.Dtos;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Features.Products.Queries.GetAllProductsByName
{
    public class GetAllProductsByNameQueryHandler : IRequestHandler<GetAllProductsByNameQueryRequest, GetAllProductsByNameQueryResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllProductsByNameQueryHandler> _logger;

        public GetAllProductsByNameQueryHandler(IProductRepository productRepository, IMapper mapper, ILogger<GetAllProductsByNameQueryHandler> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetAllProductsByNameQueryResponse> Handle(GetAllProductsByNameQueryRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching products matching name: {Name}", request.Name);
            var products = await _productRepository.GetAllProductsByName(request.Name);
            var productList = _mapper.Map<List<Product>, List<ProductDto>>(products.ToList());
            _logger.LogInformation("Retrieved {Count} products for name filter: {Name}", productList.Count, request.Name);

            return new GetAllProductsByNameQueryResponse
            {
                Products = productList
            };
        }
    }
}
