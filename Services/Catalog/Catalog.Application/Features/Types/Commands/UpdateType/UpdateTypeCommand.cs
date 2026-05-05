using MediatR;

namespace Catalog.Application.Features.Types.Commands.UpdateType
{
    public class UpdateTypeCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public string Type { get; set; }
    }
}
