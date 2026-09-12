using AutoMapper;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Features.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, bool>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateBrandCommandHandler> _logger;

        public UpdateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, ILogger<UpdateBrandCommandHandler> logger)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Updating brand with ID: {BrandId}", request.Id);
            var brandEntity = _mapper.Map<ProductBrand>(request);
            var result = await _brandRepository.UpdateBrand(brandEntity);
            _logger.LogInformation("Brand update result for ID {BrandId}: {Result}", request.Id, result);
            return result;
        }
    }
}
