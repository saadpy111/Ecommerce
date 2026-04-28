using AutoMapper;
using Catalog.Application.Dtos;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Brands.Queries.GetAllBrands
{
    public class GetAllBarndsQueryHandler : IRequestHandler<GetAllBarndsQueryRequest, GetAllBarndsQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBrandRepository _brandRepository;

        public GetAllBarndsQueryHandler(IMapper mapper , IBrandRepository brandRepository)
        {
           _mapper = mapper;
           _brandRepository = brandRepository;
        }
        public async Task<GetAllBarndsQueryResponse> Handle(GetAllBarndsQueryRequest request, CancellationToken cancellationToken)
        {
            var brands = await _brandRepository.GetAllBrands();
            var brandResponse = _mapper.Map<List<ProductBrand>, List<ProductBrandDro>>(brands.ToList());
            return new GetAllBarndsQueryResponse()
            {
                ProductBrands = brandResponse
            };
        }
    }
}
