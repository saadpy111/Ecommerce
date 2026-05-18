using Discount.Core.Repositories;
using MediatR;

namespace Discount.Application.Features.Commands.DeleteDiscount
{
    public class DeleteDiscountCommandHandler : IRequestHandler<DeleteDiscountCommand, bool>
    {
        private readonly IDiscountRepository _discountRepository;

        public DeleteDiscountCommandHandler(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public async Task<bool> Handle(DeleteDiscountCommand request, CancellationToken cancellationToken)
        {
            return await _discountRepository.DeleteDiscount(request.ProductName);
        }
    }
}
