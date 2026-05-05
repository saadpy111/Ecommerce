using AutoMapper;
using Catalog.Application.Dtos;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, ProductBrandDto>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<ProductBrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brandEntity = _mapper.Map<ProductBrand>(request);
            var result = await _brandRepository.CreateBrand(brandEntity);
            var response = _mapper.Map<ProductBrandDto>(result);
            return response;
        }
    }
}
