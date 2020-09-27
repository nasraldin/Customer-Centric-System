using FluentValidation;
using FluentValidation.Validators;

namespace CustomerService.Core.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(x => x.Address).MaximumLength(60);
            RuleFor(x => x.CompanyName).MaximumLength(40).NotEmpty();
            RuleFor(x => x.Country).MaximumLength(15);
            RuleFor(c => c.Mobile)
                .Must(HaveQueenslandLandLine)
                .When(c => c.Country == "UAE")
                .WithMessage("Customers in UAE require at start 05.");
            RuleFor(x => x.Region).MaximumLength(15);
        }

        private static bool HaveQueenslandLandLine(UpdateCustomerCommand model, string mobileValue, PropertyValidatorContext ctx)
        {
            return model.Mobile.StartsWith("05");
        }
    }
}
