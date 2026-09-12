using AutoMapper;
using Catalog.Application.Dtos;
using Catalog.Application.Features.Brands.Queries.GetAllBrands;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<GetAllTypesQueryHandler> _logger;

        public GetAllTypesQueryHandler(IMapper mapper, ITypeRepository typeRepository, ILogger<GetAllTypesQueryHandler> logger)
        {
           _mapper = mapper;
           _typeRepository = typeRepository;
           _logger = logger;
        }
        public async Task<GetAllTypesQueryResponse> Handle(GetAllTypesQueryRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching all product types");
            var Types = await _typeRepository.GetAllTypes();
            var typesResponse = _mapper.Map<List<ProductType>, List<ProductTypeDto>>(Types.ToList());
            _logger.LogInformation("Retrieved {Count} product types", typesResponse.Count);
            return new GetAllTypesQueryResponse()
            {
                 ProductTypes = typesResponse
            };
        }
    }
}
