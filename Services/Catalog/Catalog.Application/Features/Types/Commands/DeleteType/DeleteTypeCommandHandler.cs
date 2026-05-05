using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Features.Types.Commands.DeleteType
{
    public class DeleteTypeCommandHandler : IRequestHandler<DeleteTypeCommand, bool>
    {
        private readonly ITypeRepository _typeRepository;

        public DeleteTypeCommandHandler(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<bool> Handle(DeleteTypeCommand request, CancellationToken cancellationToken)
        {
            return await _typeRepository.DeleteType(request.Id);
        }
    }
}
