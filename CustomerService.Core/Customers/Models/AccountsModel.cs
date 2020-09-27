using System.Collections.Generic;

namespace CustomerService.Core.Customers.Models
{
    public class AccountsListVm
    {
        public IList<AccountDto> Accounts { get; set; }
    }

    public class AccountDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Type { get; set; }
        public float Balance { get; set; }
    }
}
