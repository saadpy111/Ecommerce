using Basket.Application.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Basket.Application.Features.Basket.Commands.CreateShoppingCart
{
    public class CreateShoppingCartCommand : IRequest<ShoppingCartResponse>
    {
        public string UserName { get; set; }
        public List<ShoppingCartItemResponse> Items { get; set; } = new List<ShoppingCartItemResponse>();

        public CreateShoppingCartCommand()
        {
            
        }

        public CreateShoppingCartCommand(string userName, List<ShoppingCartItemResponse> items)
        {
            UserName = userName;
            Items = items;
        }
    }
}
