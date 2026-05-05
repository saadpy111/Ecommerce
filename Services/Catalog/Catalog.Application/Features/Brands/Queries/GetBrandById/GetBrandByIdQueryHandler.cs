using AutoMapper;
using Catalog.Application.Dtos;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Features.Brands.Queries.GetBrandById
{
    public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQueryRequest, GetBrandByIdQueryResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public GetBrandByIdQueryHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<GetBrandByIdQueryResponse> Handle(GetBrandByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetBrandById(request.Id);
            var response = new GetBrandByIdQueryResponse
            {
                Brand = _mapper.Map<ProductBrandDto>(brand)
            };
            return response;
        }
    }
}
