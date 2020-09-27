using MediatR;

namespace AccountService.Core.Accounts.Queries.GetAccountsList
{
    public class GetAccountsListQuery : IRequest<AccountsListVm>
    {
        public int CustomerId { get; set; }
    }
}
