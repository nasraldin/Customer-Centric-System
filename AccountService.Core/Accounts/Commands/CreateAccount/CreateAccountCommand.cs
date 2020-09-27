using AccountService.Core.Common.Interfaces;
using AccountService.Core.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AccountService.Core.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommand : IRequest
    {
        public int Number { get; set; }
        public string Type { get; set; }
        public float Balance { get; set; }
        public int CustomerId { get; set; }


        public class Handler : IRequestHandler<CreateAccountCommand>
        {
            private readonly IApplicationDbContext _context;

            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
            {
                var entity = new Account
                {
                    Number = request.Number,
                    Type = request.Type,
                    Balance = request.Balance,
                    CustomerId = request.CustomerId
                };

                await _context.Accounts.AddAsync(entity, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
