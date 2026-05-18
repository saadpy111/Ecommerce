using Discount.Application.Features.Commands.CreateDiscount;
using Discount.Application.Features.Commands.DeleteDiscount;
using Discount.Application.Features.Commands.UpdateDiscount;
using Discount.Application.Features.Queries.GetDiscount;
using Discount.Grpc.Protos;
using Grpc.Core;
using MediatR;
using static Discount.Grpc.Protos.DiscountProtoService;

namespace Discount.Api.Services
{
    public class DiscountService : DiscountProtoServiceBase
    {

        private readonly IMediator _mediator;

        public DiscountService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var query = new GetDiscountQuery(request.ProductName);
            var coupon = await _mediator.Send(query);
            return coupon;
        }

        public override async Task<DiscountResponse> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var command = new  CreateDiscountCommand()
            {
                 Amount = request.Coupon.Amount,
                  Description = request.Coupon.Description,
                   ProductName = request.Coupon.ProductName
            };
            var coupon = await _mediator.Send(command);
            if (coupon != null)
            {

                return new DiscountResponse()
                {
                    Success =true
                };
            }
            return new DiscountResponse() { Success = false };

        }

        public override async Task<DiscountResponse> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var command = new UpdateDiscountCommand()
            {

                Amount = request.Coupon.Amount,
                Description = request.Coupon.Description,
                ProductName = request.Coupon.ProductName,
                Id = request.Coupon.Id
            };
            var coupon = await _mediator.Send(command);
            if (coupon != null)
            {

                return new DiscountResponse()
                {
                    Success = true
                };
            }
            return new DiscountResponse() { Success = false };

        }

        public override async Task<DiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var command = new DeleteDiscountCommand(request.ProductName);
            var deleted = await _mediator.Send(command);
            var response = new DiscountResponse
            {
                Success = deleted
            };

            return response;
        }

    }
}
