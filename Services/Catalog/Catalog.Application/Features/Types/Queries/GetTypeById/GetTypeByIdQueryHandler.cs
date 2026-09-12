using AutoMapper;
using Catalog.Application.Dtos;
using Catalog.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Features.Types.Queries.GetTypeById
{
    public class GetTypeByIdQueryHandler : IRequestHandler<GetTypeByIdQueryRequest, GetTypeByIdQueryResponse>
    {
        private readonly ITypeRepository _typeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetTypeByIdQueryHandler> _logger;

        public GetTypeByIdQueryHandler(ITypeRepository typeRepository, IMapper mapper, ILogger<GetTypeByIdQueryHandler> logger)
        {
            _typeRepository = typeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetTypeByIdQueryResponse> Handle(GetTypeByIdQueryRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching product type with ID: {TypeId}", request.Id);
            var typeEntity = await _typeRepository.GetTypeById(request.Id);
            if (typeEntity == null)
            {
                _logger.LogWarning("Product type with ID: {TypeId} was not found", request.Id);
            }
            var response = new GetTypeByIdQueryResponse
            {
                Type = _mapper.Map<ProductTypeDto>(typeEntity)
            };
            return response;
        }
    }
}
