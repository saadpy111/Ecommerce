using AutoMapper;
using Catalog.Application.Dtos;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<GetAllBarndsQueryHandler> _logger;

        public GetAllBarndsQueryHandler(IMapper mapper, IBrandRepository brandRepository, ILogger<GetAllBarndsQueryHandler> logger)
        {
           _mapper = mapper;
           _brandRepository = brandRepository;
           _logger = logger;
        }
        public async Task<GetAllBarndsQueryResponse> Handle(GetAllBarndsQueryRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching all product brands");
            var brands = await _brandRepository.GetAllBrands();
            var brandResponse = _mapper.Map<List<ProductBrand>, List<ProductBrandDto>>(brands.ToList());
            _logger.LogInformation("Retrieved {Count} product brands", brandResponse.Count);
            return new GetAllBarndsQueryResponse()
            {
                ProductBrands = brandResponse
            };
        }
    }
}
