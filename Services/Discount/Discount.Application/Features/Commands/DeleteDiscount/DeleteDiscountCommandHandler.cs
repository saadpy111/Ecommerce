using Discount.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Discount.Application.Features.Commands.DeleteDiscount
{
    public class DeleteDiscountCommandHandler : IRequestHandler<DeleteDiscountCommand, bool>
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly ILogger<DeleteDiscountCommandHandler> _logger;

        public DeleteDiscountCommandHandler(IDiscountRepository discountRepository, ILogger<DeleteDiscountCommandHandler> logger)
        {
            _discountRepository = discountRepository;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteDiscountCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Deleting discount for Product: {ProductName}", request.ProductName);
            var result = await _discountRepository.DeleteDiscount(request.ProductName);
            _logger.LogInformation("Discount deletion result for Product {ProductName}: {Result}", request.ProductName, result);
            return result;
        }
    }
}
