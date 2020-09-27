using FluentValidation;

namespace StatementService.Core.Statements.Commands.CreateStatement
{
    public class CreateStatementCommandValidator : AbstractValidator<CreateStatementCommand>
    {
        public CreateStatementCommandValidator()
        {
            RuleFor(x => x.IssueData).NotNull();
            RuleFor(x => x.AccountId).NotNull();
        }
    }
}
