using MediatR;
using StatementService.Core.Common.Interfaces;
using StatementService.Core.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StatementService.Core.Statements.Commands.CreateStatement
{
    public class CreateStatementCommand : IRequest
    {
        public DateTime IssueData { get; set; }
        public int AccountId { get; set; }


        public class Handler : IRequestHandler<CreateStatementCommand>
        {
            private readonly IApplicationDbContext _context;

            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CreateStatementCommand request, CancellationToken cancellationToken)
            {
                var entity = new Statement
                {
                    IssueData = request.IssueData,
                    AccountId = request.AccountId
                };

                await _context.Statements.AddAsync(entity, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
