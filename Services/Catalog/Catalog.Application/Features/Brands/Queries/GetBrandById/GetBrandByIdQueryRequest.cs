using MediatR;

namespace Catalog.Application.Features.Brands.Queries.GetBrandById
{
    public class GetBrandByIdQueryRequest : IRequest<GetBrandByIdQueryResponse>
    {
        public string Id { get; set; }

        public GetBrandByIdQueryRequest(string id)
        {
            Id = id;
        }
    }
}
