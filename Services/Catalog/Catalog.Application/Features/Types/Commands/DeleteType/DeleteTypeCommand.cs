using MediatR;

namespace Catalog.Application.Features.Types.Commands.DeleteType
{
    public class DeleteTypeCommand : IRequest<bool>
    {
        public string Id { get; set; }

        public DeleteTypeCommand(string id)
        {
            Id = id;
        }
    }
}
