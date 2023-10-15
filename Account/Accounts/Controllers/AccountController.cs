using AccountModels.DTO;
using AccountModels.Models;
using AccountServices;
using AccountServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace Accounts.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// «remarks>
        /// body input parameters are required to call this API
        /// </remarks> 
        /// <response code="200">Success</response> 
        /// «response code="400">Bad Request</response> 
        /// «response code="500"> Internal Server Error</responses / «response code-"401">Unauthorized</responses
        [ProducesResponseType(200, Type = typeof(Account))]
        [ProducesResponseType(400, Type = typeof(BadRequestObjectResult))]
        [ProducesResponseType(401, Type = typeof(UnauthorizedObjectResult))]
        [HttpPost]
        public IActionResult addAccount([FromBody] Account account)
        {

            return Ok(_accountService.addAccount(account));
        }

        /// <summary>
        /// 
        /// </summary>
        /// «remarks>
        /// body input parameters are required to call this API
        /// </remarks> 
        /// <response code="200">Success</response> 
        /// «response code="400">Bad Request</response> 
        /// «response code="500"> Internal Server Error</responses / «response code-"401">Unauthorized</responses
        [ProducesResponseType(200, Type = typeof(AccountResponseDTO))]
        [ProducesResponseType(400, Type = typeof(BadRequestObjectResult))]
        [ProducesResponseType(401, Type = typeof(UnauthorizedObjectResult))]
        [HttpGet]
        public IActionResult GetCustomersAccounts(long customerId)
        {
            return Ok(_accountService.GetCustomersAccounts(customerId));
        }
        /// <summary>
        /// 
        /// </summary>
        /// «remarks>
        /// body input parameters are required to call this API
        /// </remarks> 
        /// <response code="200">Success</response> 
        /// «response code="400">Bad Request</response> 
        /// «response code="500"> Internal Server Error</responses / «response code-"401">Unauthorized</responses
        [ProducesResponseType(200, Type = typeof(List<Transaction>))]
        [ProducesResponseType(400, Type = typeof(BadRequestObjectResult))]
        [ProducesResponseType(401, Type = typeof(UnauthorizedObjectResult))]
        [HttpGet]
        [Route("getTransactions")]
        public IActionResult AccountTransactions(long accountId)
        {
            return Ok(_accountService.GetAccountTransaction(accountId));
        }
    }
}
