using CustomerService.Core.Common.Mappings;
using CustomerService.Core.Customers.Models;
using CustomerService.Core.Entities;
using System.Collections.Generic;

namespace CustomerService.Core.Customers.Queries.GetCustomerDetail
{
    public class CustomerDetailVm : IMapFrom<Customer>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public IList<AccountDto> Accounts { get; set; }
    }
}
