using System.Linq;
using AccountService.Core.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AccountService.Core.Accounts.Queries.GetAccountsList
{
    public class GetAccountsListQueryHandler : IRequestHandler<GetAccountsListQuery, AccountsListVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAccountsListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AccountsListVm> Handle(GetAccountsListQuery request, CancellationToken cancellationToken)
        {
            var accounts = await _context.Accounts.Where(a => a.CustomerId == request.CustomerId).ProjectTo<AccountLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new AccountsListVm
            {
                Accounts = accounts
            };

            return vm;
        }
    }
}
