namespace BasicBilling.Services.Validators
{
    using FluentValidation;
    using Models;

    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator(decimal remainingBalance)
        {
            RuleFor(x => x.BillId)
                .NotEmpty();

            RuleFor(x => x.Amount)
                .NotEmpty()
                .GreaterThan(0)
                .LessThanOrEqualTo(remainingBalance)
                .WithMessage("Amount payed must be less or equal to Remaining Balance");
        }
    }
}
