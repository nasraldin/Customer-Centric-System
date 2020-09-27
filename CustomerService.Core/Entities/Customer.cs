namespace CustomerService.Core.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Mobile { get; set; }
    }
}
