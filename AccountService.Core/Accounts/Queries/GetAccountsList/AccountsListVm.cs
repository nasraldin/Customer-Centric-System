using System.Collections.Generic;

namespace AccountService.Core.Accounts.Queries.GetAccountsList
{
    public class AccountsListVm
    {
        public IList<AccountLookupDto> Accounts { get; set; }
    }
}
