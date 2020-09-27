using AccountService.Core.Accounts.Commands.CreateAccount;
using AccountService.Core.Accounts.Queries.GetAccountsList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AccountService.API.Controllers.v1
{
    public class AccountsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<AccountsListVm>> GetAll(int customerId)
        {
            var vm = await Mediator.Send(new GetAccountsListQuery { CustomerId = customerId });

            return Ok(vm);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateAccountCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}