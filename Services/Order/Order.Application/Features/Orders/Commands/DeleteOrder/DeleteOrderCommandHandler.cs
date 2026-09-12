using MediatR;
using Microsoft.Extensions.Logging;
using Order.Core.Repositories;

namespace Order.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<DeleteOrderCommandHandler> _logger;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository, ILogger<DeleteOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Deleting order with ID: {OrderId}", request.Id);
            var orderToDelete = await _orderRepository.GetByIdAsync(request.Id);
            if (orderToDelete == null)
            {
                _logger.LogWarning("Order with ID: {OrderId} was not found for deletion", request.Id);
                return false;
            }

            await _orderRepository.DeleteAsync(orderToDelete);
            _logger.LogInformation("Successfully deleted order with ID: {OrderId}", request.Id);
            return true;
        }
    }
}
