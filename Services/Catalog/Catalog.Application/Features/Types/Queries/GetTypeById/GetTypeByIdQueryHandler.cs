using AutoMapper;
using Catalog.Application.Dtos;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Features.Types.Queries.GetTypeById
{
    public class GetTypeByIdQueryHandler : IRequestHandler<GetTypeByIdQueryRequest, GetTypeByIdQueryResponse>
    {
        private readonly ITypeRepository _typeRepository;
        private readonly IMapper _mapper;

        public GetTypeByIdQueryHandler(ITypeRepository typeRepository, IMapper mapper)
        {
            _typeRepository = typeRepository;
            _mapper = mapper;
        }

        public async Task<GetTypeByIdQueryResponse> Handle(GetTypeByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var typeEntity = await _typeRepository.GetTypeById(request.Id);
            var response = new GetTypeByIdQueryResponse
            {
                Type = _mapper.Map<ProductTypeDto>(typeEntity)
            };
            return response;
        }
    }
}
