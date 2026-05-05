using Catalog.Application.Dtos;
using MediatR;

namespace Catalog.Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommand : IRequest<ProductBrandDto>
    {
        public string Name { get; set; }
    }
}
