using AccountServices;
using Microsoft.AspNetCore.Mvc;

namespace Accounts.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public CustomersController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public IActionResult GetLookupByParantCode()
        {
            var result = _accountService.getCustomers();

            return Ok(result);
        }
    }
}
