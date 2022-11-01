using BusinessLogic.DTOs;
using DataAccess.Entities;
using FluentValidation;
namespace BusinessLogic.Validators
{
    public class TransactionValidatior:AbstractValidator<TransactionDTO>
    {
        public TransactionValidatior()
        {
            RuleFor(t => t.Sum)
                .NotNull()
                .NotEmpty()
                .InclusiveBetween(1, 10000000);

            RuleFor(t => t.TypeTransactionID)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(t => t.DateTime)
                .NotNull()
                .NotEmpty();

            RuleFor(t => t.SenderName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100);

            RuleFor(t => t.RecipientName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100);

            RuleFor(t => t.Description)
                .MinimumLength(1)
                .MaximumLength(140);
        }
    }
}
