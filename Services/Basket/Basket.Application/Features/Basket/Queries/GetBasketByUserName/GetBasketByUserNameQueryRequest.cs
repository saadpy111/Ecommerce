using MediatR;

namespace Basket.Application.Features.Basket.Queries.GetBasketByUserName
{
    public class GetBasketByUserNameQueryRequest : IRequest<GetBasketByUserNameQueryResponse>
    {
        public string UserName { get; set; }

        public GetBasketByUserNameQueryRequest(string userName)
        {
            UserName = userName;
        }
    }
}
