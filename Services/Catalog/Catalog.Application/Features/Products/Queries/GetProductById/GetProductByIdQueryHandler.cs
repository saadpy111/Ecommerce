using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Catalog.Application.Dtos;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, GetProductByIdQueryResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetProductByIdQueryHandler> _logger;

        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper, ILogger<GetProductByIdQueryHandler> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching product with ID: {ProductId}", request.Id);
            var product = await _productRepository.GetProductById(request.Id);
            if (product == null)
            {
                _logger.LogWarning("Product with ID: {ProductId} was not found", request.Id);
            }
            var productDto = _mapper.Map<Product, ProductDto>(product);

            return new GetProductByIdQueryResponse
            {
                Product = productDto
            };
        }
    }
}
