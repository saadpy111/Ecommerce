using MediatR;

namespace Basket.Application.Features.Basket.Commands.DeleteBasketByUserName
{
    public class DeleteBasketByUserNameCommand : IRequest<bool>
    {
        public string UserName { get; set; }

        public DeleteBasketByUserNameCommand(string userName)
        {
            UserName = userName;
        }
    }
}
