using AutoMapper;
using Discount.Core.Repositories;
using Discount.Grpc.Protos;
using Grpc.Core;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Discount.Application.Features.Queries.GetDiscount
{
    public class GetDiscountQueryHandler : IRequestHandler<GetDiscountQuery, CouponModel>
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetDiscountQueryHandler> _logger;

        public GetDiscountQueryHandler(IDiscountRepository discountRepository, IMapper mapper, ILogger<GetDiscountQueryHandler> logger)
        {
            _discountRepository = discountRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CouponModel> Handle(GetDiscountQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching discount for Product: {ProductName}", request.ProductName);
            var coupon = await _discountRepository.GetDiscount(request.ProductName);

            if (coupon == null)
            {
                _logger.LogWarning("Discount for Product: {ProductName} was not found", request.ProductName);
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount with ProductName={request.ProductName} is not found."));
            }

            _logger.LogInformation("Retrieved discount for Product: {ProductName}, Amount: {Amount}", request.ProductName, coupon.Amount);
            return _mapper.Map<CouponModel>(coupon);
        }
    }
}
