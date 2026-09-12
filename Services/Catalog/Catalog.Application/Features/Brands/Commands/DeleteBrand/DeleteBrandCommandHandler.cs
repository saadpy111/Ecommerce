using Catalog.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Features.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, bool>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly ILogger<DeleteBrandCommandHandler> _logger;

        public DeleteBrandCommandHandler(IBrandRepository brandRepository, ILogger<DeleteBrandCommandHandler> logger)
        {
            _brandRepository = brandRepository;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Deleting brand with ID: {BrandId}", request.Id);
            var result = await _brandRepository.DeleteBrand(request.Id);
            _logger.LogInformation("Brand deletion result for ID {BrandId}: {Result}", request.Id, result);
            return result;
        }
    }
}
