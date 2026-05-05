using AutoMapper;
using Catalog.Application.Dtos;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Features.Types.Commands.CreateType
{
    public class CreateTypeCommandHandler : IRequestHandler<CreateTypeCommand, ProductTypeDto>
    {
        private readonly ITypeRepository _typeRepository;
        private readonly IMapper _mapper;

        public CreateTypeCommandHandler(ITypeRepository typeRepository, IMapper mapper)
        {
            _typeRepository = typeRepository;
            _mapper = mapper;
        }

        public async Task<ProductTypeDto> Handle(CreateTypeCommand request, CancellationToken cancellationToken)
        {
            var typeEntity = _mapper.Map<ProductType>(request);
            var result = await _typeRepository.CreateType(typeEntity);
            var response = _mapper.Map<ProductTypeDto>(result);
            return response;
        }
    }
}
