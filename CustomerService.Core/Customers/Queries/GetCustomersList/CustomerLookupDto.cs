using AutoMapper;
using CustomerService.Core.Common.Mappings;
using CustomerService.Core.Entities;

namespace CustomerService.Core.Customers.Queries.GetCustomersList
{
    public class CustomerLookupDto : IMapFrom<Customer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
    }
}
