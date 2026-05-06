using Catalog.Core.Specs;
using MediatR;

namespace Catalog.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryRequest : IRequest<GetAllProductsQueryResponse>
    {
        public CatalogSpecParams  Params { get; set; }
    }
}
