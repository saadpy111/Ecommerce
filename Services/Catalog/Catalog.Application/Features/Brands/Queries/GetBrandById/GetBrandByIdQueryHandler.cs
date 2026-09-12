using AutoMapper;
using Catalog.Application.Dtos;
using Catalog.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Features.Brands.Queries.GetBrandById
{
    public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQueryRequest, GetBrandByIdQueryResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetBrandByIdQueryHandler> _logger;

        public GetBrandByIdQueryHandler(IBrandRepository brandRepository, IMapper mapper, ILogger<GetBrandByIdQueryHandler> logger)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetBrandByIdQueryResponse> Handle(GetBrandByIdQueryRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching brand with ID: {BrandId}", request.Id);
            var brand = await _brandRepository.GetBrandById(request.Id);
            if (brand == null)
            {
                _logger.LogWarning("Brand with ID: {BrandId} was not found", request.Id);
            }
            var response = new GetBrandByIdQueryResponse
            {
                Brand = _mapper.Map<ProductBrandDto>(brand)
            };
            return response;
        }
    }
}
