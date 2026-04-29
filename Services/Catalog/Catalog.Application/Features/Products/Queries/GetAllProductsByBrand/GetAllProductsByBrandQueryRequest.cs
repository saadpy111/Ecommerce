using MediatR;

namespace Catalog.Application.Features.Products.Queries.GetAllProductsByBrand
{
    public class GetAllProductsByBrandQueryRequest : IRequest<GetAllProductsByBrandQueryResponse>
    {
        public string BrandName { get; set; }

        public GetAllProductsByBrandQueryRequest(string brandName)
        {
            BrandName = brandName;
        }
    }
}
