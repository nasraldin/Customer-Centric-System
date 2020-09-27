using FluentValidation;

namespace CustomerService.Core.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.Name).MaximumLength(60).NotEmpty();
            RuleFor(x => x.Address).MaximumLength(100);
            RuleFor(x => x.CompanyName).MaximumLength(40);
            RuleFor(x => x.Country).MaximumLength(15);
            RuleFor(x => x.Mobile).MaximumLength(10);
            RuleFor(x => x.Region).MaximumLength(15);
        }
    }
}
