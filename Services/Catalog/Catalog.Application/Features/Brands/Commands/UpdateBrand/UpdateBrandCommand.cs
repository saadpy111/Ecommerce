using MediatR;

namespace Catalog.Application.Features.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public string BrandName { get; set; }
    }
}
