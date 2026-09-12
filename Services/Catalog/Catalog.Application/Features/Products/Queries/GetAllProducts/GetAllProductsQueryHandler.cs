using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Catalog.Application.Dtos;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Core.Specs;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, GetAllProductsQueryResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllProductsQueryHandler> _logger;

        public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper, ILogger<GetAllProductsQueryHandler> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetAllProductsQueryResponse> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching products with catalog specs: {@Params}", request.Params);
            var products = await _productRepository.GetAllProducts(request.Params);
            var paginationProducts = _mapper.Map<Pagination<Product>, Pagination<ProductDto>>(products);
            _logger.LogInformation("Retrieved {Count} products for page index {PageIndex}", paginationProducts.Data.Count, paginationProducts.PageIndex);

            return new GetAllProductsQueryResponse
            {
                Products = paginationProducts
            };
        }
    }
}
