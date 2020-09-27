using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StatementService.Core.Statements.Commands.CreateStatement;
using StatementService.Core.Statements.Queries.GetStatementsList;
using System.Threading.Tasks;

namespace StatementService.API.Controllers.v1
{
    public class StatementsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<StatementsListVm>> GetAll(int accountId)
        {
            var vm = await Mediator.Send(new GetStatementsListQuery { AccountId = accountId });

            return Ok(vm);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateStatementCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}