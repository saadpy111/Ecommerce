using AutoMapper;
using EventBus.Messages.Events;
using Order.Application.Dtos;
using Order.Application.Features.Orders.Commands.CheckoutOrder;
using Order.Application.Features.Orders.Commands.UpdateOrder;

namespace Order.Application.Mappers
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order.Core.Entities.Order, OrderResponseDto>().ReverseMap();
            CreateMap<CheckoutOrderCommand, Order.Core.Entities.Order>();
            CreateMap<UpdateOrderCommand, Order.Core.Entities.Order>();
            CreateMap<BasketCheckoutEvent, CheckoutOrderCommand>();
        }
    }
}
