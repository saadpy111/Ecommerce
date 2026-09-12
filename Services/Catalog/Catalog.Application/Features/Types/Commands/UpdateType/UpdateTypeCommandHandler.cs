using AutoMapper;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Features.Types.Commands.UpdateType
{
    public class UpdateTypeCommandHandler : IRequestHandler<UpdateTypeCommand, bool>
    {
        private readonly ITypeRepository _typeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateTypeCommandHandler> _logger;

        public UpdateTypeCommandHandler(ITypeRepository typeRepository, IMapper mapper, ILogger<UpdateTypeCommandHandler> logger)
        {
            _typeRepository = typeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> Handle(UpdateTypeCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Updating product type with ID: {TypeId}", request.Id);
            var typeEntity = _mapper.Map<ProductType>(request);
            var result = await _typeRepository.UpdateType(typeEntity);
            _logger.LogInformation("Product type update result for ID {TypeId}: {Result}", request.Id, result);
            return result;
        }
    }
}
