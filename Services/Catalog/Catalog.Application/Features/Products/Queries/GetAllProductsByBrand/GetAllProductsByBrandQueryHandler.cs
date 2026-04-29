using AutoMapper;
using Catalog.Application.Dtos;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Features.Products.Queries.GetAllProductsByBrand
{
    public class GetAllProductsByBrandQueryHandler : IRequestHandler<GetAllProductsByBrandQueryRequest, GetAllProductsByBrandQueryResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsByBrandQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetAllProductsByBrandQueryResponse> Handle(GetAllProductsByBrandQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllProductsByBrand(request.BrandName);
            var productList = _mapper.Map<List<Product>, List<ProductDto>>(products.ToList());

            return new GetAllProductsByBrandQueryResponse
            {
                Products = productList
            };
        }
    }
}
