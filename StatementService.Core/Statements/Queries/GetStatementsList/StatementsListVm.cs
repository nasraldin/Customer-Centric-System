using System.Collections.Generic;

namespace StatementService.Core.Statements.Queries.GetStatementsList
{
    public class StatementsListVm
    {
        public IList<StatementLookupDto> Statements { get; set; }
    }
}
