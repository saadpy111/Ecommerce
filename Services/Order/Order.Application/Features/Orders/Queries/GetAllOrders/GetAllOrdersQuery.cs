using MediatR;
using Order.Application.Dtos;

namespace Order.Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQuery : IRequest<List<OrderResponseDto>>
    {
    }
}
