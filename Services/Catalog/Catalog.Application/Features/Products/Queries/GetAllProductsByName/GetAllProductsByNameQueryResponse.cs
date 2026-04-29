using Catalog.Application.Dtos;

namespace Catalog.Application.Features.Products.Queries.GetAllProductsByName
{
    public class GetAllProductsByNameQueryResponse
    {
        public List<ProductDto> Products { get; set; }
    }
}
