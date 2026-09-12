using Basket.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Basket.Application.Features.Basket.Commands.DeleteBasketByUserName
{
    public class DeleteBasketByUserNameCommandHandler : IRequestHandler<DeleteBasketByUserNameCommand, bool>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly ILogger<DeleteBasketByUserNameCommandHandler> _logger;

        public DeleteBasketByUserNameCommandHandler(IBasketRepository basketRepository, ILogger<DeleteBasketByUserNameCommandHandler> logger)
        {
            _basketRepository = basketRepository;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteBasketByUserNameCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Deleting shopping basket for UserName: {UserName}", request.UserName);
            await _basketRepository.DeleteBasket(request.UserName);
            _logger.LogInformation("Successfully deleted shopping basket for UserName: {UserName}", request.UserName);
            return true;
        }
    }
}
