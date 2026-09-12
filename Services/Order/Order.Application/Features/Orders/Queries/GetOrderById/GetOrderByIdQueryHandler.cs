using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Order.Application.Dtos;
using Order.Core.Repositories;

namespace Order.Application.Features.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderResponseDto?>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetOrderByIdQueryHandler> _logger;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<GetOrderByIdQueryHandler> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<OrderResponseDto?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching order with ID: {OrderId}", request.Id);
            var order = await _orderRepository.GetByIdAsync(request.Id);
            if (order == null)
            {
                _logger.LogWarning("Order with ID: {OrderId} was not found", request.Id);
                return null;
            }
            _logger.LogInformation("Successfully retrieved order with ID: {OrderId}", request.Id);
            return _mapper.Map<OrderResponseDto>(order);
        }
    }
}
