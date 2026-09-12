using Catalog.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Features.Types.Commands.DeleteType
{
    public class DeleteTypeCommandHandler : IRequestHandler<DeleteTypeCommand, bool>
    {
        private readonly ITypeRepository _typeRepository;
        private readonly ILogger<DeleteTypeCommandHandler> _logger;

        public DeleteTypeCommandHandler(ITypeRepository typeRepository, ILogger<DeleteTypeCommandHandler> logger)
        {
            _typeRepository = typeRepository;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteTypeCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Deleting product type with ID: {TypeId}", request.Id);
            var result = await _typeRepository.DeleteType(request.Id);
            _logger.LogInformation("Product type deletion result for ID {TypeId}: {Result}", request.Id, result);
            return result;
        }
    }
}
