using AutoMapper;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using Discount.Grpc.Protos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Discount.Application.Features.Commands.CreateDiscount
{
    public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommand, CouponModel>
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateDiscountCommandHandler> _logger;

        public CreateDiscountCommandHandler(IDiscountRepository discountRepository, IMapper mapper, ILogger<CreateDiscountCommandHandler> logger)
        {
            _discountRepository = discountRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CouponModel> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating discount for Product: {ProductName}, Amount: {Amount}", request.ProductName, request.Amount);
            var coupon = _mapper.Map<Coupon>(request);
            await _discountRepository.CreateDiscount(coupon);
            
            var createdCoupon = await _discountRepository.GetDiscount(coupon.ProductName);
            _logger.LogInformation("Successfully created discount for Product: {ProductName}", coupon.ProductName);
            return _mapper.Map<CouponModel>(createdCoupon);
        }
    }
}
