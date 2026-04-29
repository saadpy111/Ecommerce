using Catalog.Application.Dtos;

namespace Catalog.Application.Features.Products.Queries.GetAllProductsByBrand
{
    public class GetAllProductsByBrandQueryResponse
    {
        public List<ProductDto> Products { get; set; }
    }
}
