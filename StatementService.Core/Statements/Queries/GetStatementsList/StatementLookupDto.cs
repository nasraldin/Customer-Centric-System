using StatementService.Core.Common.Mappings;
using StatementService.Core.Entities;
using System;

namespace StatementService.Core.Statements.Queries.GetStatementsList
{
    public class StatementLookupDto : IMapFrom<Statement>
    {
        public int Id { get; set; }
        public DateTime IssueData { get; set; }
        public int AccountId { get; set; }
    }
}
