using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Features.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, bool>
    {
        private readonly IBrandRepository _brandRepository;

        public DeleteBrandCommandHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<bool> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            return await _brandRepository.DeleteBrand(request.Id);
        }
    }
}
