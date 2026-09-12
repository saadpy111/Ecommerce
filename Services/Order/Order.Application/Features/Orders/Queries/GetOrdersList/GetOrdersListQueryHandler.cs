using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Order.Application.Dtos;
using Order.Core.Repositories;

namespace Order.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, List<OrderResponseDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetOrdersListQueryHandler> _logger;

        public GetOrdersListQueryHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<GetOrdersListQueryHandler> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<OrderResponseDto>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching order list for UserName: {UserName}", request.UserName);
            var orderList = await _orderRepository.GetOrdersByUserName(request.UserName);
            var response = _mapper.Map<List<OrderResponseDto>>(orderList);
            _logger.LogInformation("Retrieved {Count} orders for UserName: {UserName}", response.Count, request.UserName);
            return response;
        }
    }
}
