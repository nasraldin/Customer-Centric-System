using MediatR;

namespace StatementService.Core.Statements.Queries.GetStatementsList
{
    public class GetStatementsListQuery : IRequest<StatementsListVm>
    {
        public int AccountId { get; set; }
    }
}
