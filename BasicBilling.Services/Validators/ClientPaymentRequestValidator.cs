namespace BasicBilling.Services.Validators
{
    using FluentValidation;
    using Models;

    public  class ClientPaymentRequestValidator : AbstractValidator<ClientPaymentRequest>
    {
        public ClientPaymentRequestValidator(decimal remainingBalance)
        {
            RuleFor(x => x.BillType)
                .NotEmpty();

            RuleFor(x => x.ClientId)
                .NotEmpty();

            RuleFor(x => x.Date)
                .NotEmpty();

            RuleFor(x => x.Amount)
                .NotEmpty()
                .GreaterThan(0)
                .LessThanOrEqualTo(remainingBalance)
                .WithMessage("Amount payed must be less or equal to Remaining Balance");
        }
    }
}
