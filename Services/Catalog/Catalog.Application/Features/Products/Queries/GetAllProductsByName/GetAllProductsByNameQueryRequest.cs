using MediatR;

namespace Catalog.Application.Features.Products.Queries.GetAllProductsByName
{
    public class GetAllProductsByNameQueryRequest : IRequest<GetAllProductsByNameQueryResponse>
    {
        public string Name { get; set; }

        public GetAllProductsByNameQueryRequest(string name)
        {
            Name = name;
        }
    }
}
