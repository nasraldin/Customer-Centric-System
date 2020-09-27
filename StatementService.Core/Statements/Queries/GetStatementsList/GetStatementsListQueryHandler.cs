using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StatementService.Core.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StatementService.Core.Statements.Queries.GetStatementsList
{
    public class GetStatementsListQueryHandler : IRequestHandler<GetStatementsListQuery, StatementsListVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetStatementsListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StatementsListVm> Handle(GetStatementsListQuery request, CancellationToken cancellationToken)
        {
            var statements = await _context.Statements.Where(a => a.AccountId == request.AccountId).ProjectTo<StatementLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            var vm = new StatementsListVm
            {
                Statements = statements
            };

            return vm;
        }
    }
}
