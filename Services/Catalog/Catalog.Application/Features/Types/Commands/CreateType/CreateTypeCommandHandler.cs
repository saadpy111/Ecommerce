using AutoMapper;
using Catalog.Application.Dtos;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Features.Types.Commands.CreateType
{
    public class CreateTypeCommandHandler : IRequestHandler<CreateTypeCommand, ProductTypeDto>
    {
        private readonly ITypeRepository _typeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateTypeCommandHandler> _logger;

        public CreateTypeCommandHandler(ITypeRepository typeRepository, IMapper mapper, ILogger<CreateTypeCommandHandler> logger)
        {
            _typeRepository = typeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ProductTypeDto> Handle(CreateTypeCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating product type with Name: {TypeName}", request.Name);
            var typeEntity = _mapper.Map<ProductType>(request);
            var result = await _typeRepository.CreateType(typeEntity);
            var response = _mapper.Map<ProductTypeDto>(result);
            _logger.LogInformation("Successfully created product type with ID: {TypeId}", response.Id);
            return response;
        }
    }
}
