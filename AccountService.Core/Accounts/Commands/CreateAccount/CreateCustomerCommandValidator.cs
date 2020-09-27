using FluentValidation;

namespace AccountService.Core.Accounts.Commands.CreateAccount
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.Number).NotNull();
            RuleFor(x => x.Type).MaximumLength(20);
            RuleFor(x => x.CustomerId).NotNull();
        }
    }
}
