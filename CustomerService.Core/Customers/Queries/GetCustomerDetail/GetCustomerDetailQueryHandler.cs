using AutoMapper;
using CustomerService.Core.Common.Exceptions;
using CustomerService.Core.Common.Interfaces;
using CustomerService.Core.Entities;
using CustomerService.Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerService.Core.Customers.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQueryHandler : IRequestHandler<GetCustomerDetailQuery, CustomerDetailVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAccountsService _accountsService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetCustomerDetailQueryHandler(IApplicationDbContext context, IMapper mapper, IAccountsService accountsService, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _accountsService = accountsService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<CustomerDetailVm> Handle(GetCustomerDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Customers
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }

            // for DEV dmeo
            var accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];

            var accountsVm = await _accountsService.GetAccounts(entity.Id, accessToken);

            var customerMap = _mapper.Map<CustomerDetailVm>(entity);
            customerMap.Accounts = accountsVm.Accounts;

            return customerMap;
        }
    }
}
