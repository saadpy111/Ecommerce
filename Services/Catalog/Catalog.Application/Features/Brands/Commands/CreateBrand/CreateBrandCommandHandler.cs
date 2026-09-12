using AutoMapper;
using Catalog.Application.Dtos;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, ProductBrandDto>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateBrandCommandHandler> _logger;

        public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, ILogger<CreateBrandCommandHandler> logger)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ProductBrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating brand with Name: {BrandName}", request.Name);
            var brandEntity = _mapper.Map<ProductBrand>(request);
            var result = await _brandRepository.CreateBrand(brandEntity);
            var response = _mapper.Map<ProductBrandDto>(result);
            _logger.LogInformation("Successfully created brand with ID: {BrandId}", response.Id);
            return response;
        }
    }
}
