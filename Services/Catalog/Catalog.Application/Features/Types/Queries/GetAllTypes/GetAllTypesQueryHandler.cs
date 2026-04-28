using AutoMapper;
using Catalog.Application.Dtos;
using Catalog.Application.Features.Brands.Queries.GetAllBrands;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Types.Queries.GetAllTypes
{
    public class GetAllTypesQueryHandler : IRequestHandler<GetAllTypesQueryRequest, GetAllTypesQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITypeRepository _typeRepository;

        public GetAllTypesQueryHandler(IMapper mapper , ITypeRepository typeRepository)
        {
           _mapper = mapper;
           _typeRepository = typeRepository;
        }
        public async Task<GetAllTypesQueryResponse> Handle(GetAllTypesQueryRequest request, CancellationToken cancellationToken)
        {
            var Types = await _typeRepository.GetAllTypes();
            var typesResponse = _mapper.Map<List<ProductType>, List<ProductTypeDto>>(Types.ToList());
            return new GetAllTypesQueryResponse()
            {
                 ProductTypes = typesResponse
            };
        }
    }
}
