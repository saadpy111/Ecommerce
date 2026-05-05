using MediatR;

namespace Catalog.Application.Features.Types.Queries.GetTypeById
{
    public class GetTypeByIdQueryRequest : IRequest<GetTypeByIdQueryResponse>
    {
        public string Id { get; set; }

        public GetTypeByIdQueryRequest(string id)
        {
            Id = id;
        }
    }
}
