using AutoMapper;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Features.Types.Commands.UpdateType
{
    public class UpdateTypeCommandHandler : IRequestHandler<UpdateTypeCommand, bool>
    {
        private readonly ITypeRepository _typeRepository;
        private readonly IMapper _mapper;

        public UpdateTypeCommandHandler(ITypeRepository typeRepository, IMapper mapper)
        {
            _typeRepository = typeRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateTypeCommand request, CancellationToken cancellationToken)
        {
            var typeEntity = _mapper.Map<ProductType>(request);
            var result = await _typeRepository.UpdateType(typeEntity);
            return result;
        }
    }
}
