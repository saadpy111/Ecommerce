using MediatR;

namespace Catalog.Application.Features.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommand : IRequest<bool>
    {
        public string Id { get; set; }

        public DeleteBrandCommand(string id)
        {
            Id = id;
        }
    }
}
