using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Order.Core.Repositories;

namespace Order.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateOrderCommandHandler> _logger;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<UpdateOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Updating order with ID: {OrderId}", request.Id);
            var orderToUpdate = await _orderRepository.GetByIdAsync(request.Id);
            if (orderToUpdate == null)
            {
                _logger.LogWarning("Order with ID: {OrderId} was not found for update", request.Id);
                return false;
            }

            _mapper.Map(request, orderToUpdate, typeof(UpdateOrderCommand), typeof(Order.Core.Entities.Order));
            await _orderRepository.UpdateAsync(orderToUpdate);
            _logger.LogInformation("Successfully updated order with ID: {OrderId}", request.Id);
            return true;
        }
    }
}
