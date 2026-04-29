using Catalog.Application.Dtos;
using MediatR;

namespace Catalog.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
        public ProductBrandDto Brand { get; set; }
        public ProductTypeDto Type { get; set; }
    }
}
