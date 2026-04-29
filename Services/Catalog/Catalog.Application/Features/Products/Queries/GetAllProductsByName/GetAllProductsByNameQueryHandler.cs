using AutoMapper;
using Catalog.Application.Dtos;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Features.Products.Queries.GetAllProductsByName
{
    public class GetAllProductsByNameQueryHandler : IRequestHandler<GetAllProductsByNameQueryRequest, GetAllProductsByNameQueryResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsByNameQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetAllProductsByNameQueryResponse> Handle(GetAllProductsByNameQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllProductsByName(request.Name);
            var productList = _mapper.Map<List<Product>, List<ProductDto>>(products.ToList());

            return new GetAllProductsByNameQueryResponse
            {
                Products = productList
            };
        }
    }
}
