using Discount.Grpc.Protos;
using MediatR;

namespace Discount.Application.Features.Queries.GetDiscount
{
    public class GetDiscountQuery : IRequest<CouponModel>
    {
        public string ProductName { get; set; }

        public GetDiscountQuery(string productName)
        {
            ProductName = productName;
        }
    }
}
