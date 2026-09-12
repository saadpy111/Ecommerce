using AutoMapper;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using Discount.Grpc.Protos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Discount.Application.Features.Commands.UpdateDiscount
{
    public class UpdateDiscountCommandHandler : IRequestHandler<UpdateDiscountCommand, CouponModel>
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateDiscountCommandHandler> _logger;

        public UpdateDiscountCommandHandler(IDiscountRepository discountRepository, IMapper mapper, ILogger<UpdateDiscountCommandHandler> logger)
        {
            _discountRepository = discountRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CouponModel> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Updating discount for Product: {ProductName}", request.ProductName);
            var coupon = _mapper.Map<Coupon>(request);
            await _discountRepository.UpdateDiscount(coupon);

            var updatedCoupon = await _discountRepository.GetDiscount(coupon.ProductName);
            _logger.LogInformation("Successfully updated discount for Product: {ProductName}", coupon.ProductName);
            return _mapper.Map<CouponModel>(updatedCoupon);
        }
    }
}
