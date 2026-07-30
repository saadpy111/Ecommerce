using FluentValidation;
namespace Order.Application.Features.Orders.Commands.DeleteOrder
{
    public  class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("ID must be not empty");
        }
    }
}
