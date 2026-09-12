using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Order.Application.Dtos;
using Order.Core.Repositories;

namespace Order.Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<OrderResponseDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllOrdersQueryHandler> _logger;

        public GetAllOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<GetAllOrdersQueryHandler> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<OrderResponseDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching all orders");
            var orderList = await _orderRepository.GetAllAsync();
            var response = _mapper.Map<List<OrderResponseDto>>(orderList);
            _logger.LogInformation("Retrieved {Count} orders", response.Count);
            return response;
        }
    }
}
