using AutoMapper;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Features.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, bool>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public UpdateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brandEntity = _mapper.Map<ProductBrand>(request);
            var result = await _brandRepository.UpdateBrand(brandEntity);
            return result;
        }
    }
}
