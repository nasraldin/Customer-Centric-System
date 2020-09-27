using CustomerService.Core.Common.Interfaces;
using CustomerService.Core.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerService.Core.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Mobile { get; set; }


        public class Handler : IRequestHandler<CreateCustomerCommand>
        {
            private readonly IApplicationDbContext _context;

            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                var entity = new Customer
                {
                    Name = request.Name,
                    CompanyName = request.CompanyName,
                    Address = request.Address,
                    Region = request.Region,
                    Country = request.Country,
                    Mobile = request.Mobile
                };

                await _context.Customers.AddAsync(entity, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
