using AutoMapper;
using Basket.Application.Dtos;
using Basket.Application.Features.Basket.Commands.CreateShoppingCart;
using Basket.Core.Entities;

namespace Basket.Application.Mappers
{
    public class BasketMappingProfile : Profile
    {
        public BasketMappingProfile()
        {
            CreateMap<ShoppingCart, ShoppingCartResponse>().ReverseMap();
            CreateMap<ShoppingCartItem, ShoppingCartItemResponse>().ReverseMap();
            CreateMap<CreateShoppingCartCommand, ShoppingCart>();
        }
    }
}
