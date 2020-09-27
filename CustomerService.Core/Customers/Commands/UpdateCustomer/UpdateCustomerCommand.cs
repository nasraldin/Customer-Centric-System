using CustomerService.Core.Common.Exceptions;
using CustomerService.Core.Common.Interfaces;
using CustomerService.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerService.Core.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Mobile { get; set; }

        public class Handler : IRequestHandler<UpdateCustomerCommand>
        {
            private readonly IApplicationDbContext _context;

            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Customers
                    .SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Customer), request.Id);
                }

                entity.Name = request.Name;
                entity.CompanyName = request.CompanyName;
                entity.Address = request.Address;
                entity.Region = request.Region;
                entity.Country = request.Country;
                entity.Mobile = request.Mobile;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
