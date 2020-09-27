using System;

namespace StatementService.Core.Entities
{
    public class Statement : BaseEntity
    {
        public DateTime IssueData { get; set; }
        public int AccountId { get; set; }
    }
}
