using AccountService.Core.Common.Mappings;
using AccountService.Core.Entities;

namespace AccountService.Core.Accounts.Queries.GetAccountsList
{
    public class AccountLookupDto : IMapFrom<Account>
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Type { get; set; }
        public float Balance { get; set; }
        public int CustomerId { get; set; }
    }
}
