using AutoMapper;
using Catalog.Application.Dtos;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Features.Products.Queries.GetAllProductsByBrand
{
    public class GetAllProductsByBrandQueryHandler : IRequestHandler<GetAllProductsByBrandQueryRequest, GetAllProductsByBrandQueryResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllProductsByBrandQueryHandler> _logger;

        public GetAllProductsByBrandQueryHandler(IProductRepository productRepository, IMapper mapper, ILogger<GetAllProductsByBrandQueryHandler> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetAllProductsByBrandQueryResponse> Handle(GetAllProductsByBrandQueryRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching products for brand: {BrandName}", request.BrandName);
            var products = await _productRepository.GetAllProductsByBrand(request.BrandName);
            var productList = _mapper.Map<List<Product>, List<ProductDto>>(products.ToList());
            _logger.LogInformation("Retrieved {Count} products for brand: {BrandName}", productList.Count, request.BrandName);

            return new GetAllProductsByBrandQueryResponse
            {
                Products = productList
            };
        }
    }
}
