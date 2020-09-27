using CustomerService.Core.Customers.Models;
using Refit;
using System.Threading.Tasks;

namespace CustomerService.Core.Interfaces
{
    public interface IAccountsService
    {
        [Get("/api/v1/accounts")]
        Task<AccountsListVm> GetAccounts(int customerId, [Header("Authorization")] string authorization);
    }
}