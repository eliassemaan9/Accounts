using AccountModels.DTO;
using AccountServices;
using Microsoft.AspNetCore.Mvc;


namespace Accounts.Controllers
{
    [ApiController]
    [Route("api/basic")]
    public class BasicController : ControllerBase
    {
        private readonly IBasicService _basicService;
        public BasicController(IBasicService basicService)
        {
            _basicService = basicService;
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
        [ProducesResponseType(200, Type = typeof(RegisterDTO))]
        [ProducesResponseType(400, Type = typeof(BadRequestObjectResult))]
        [ProducesResponseType(401, Type = typeof(UnauthorizedObjectResult))]
        [HttpPost]
        [Route("register")]
        public IActionResult register([FromBody] RegisterDTO registerDTO)
        {

            return Ok(_basicService.register(registerDTO));
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
        [ProducesResponseType(200, Type = typeof(RegisterDTO))]
        [ProducesResponseType(400, Type = typeof(BadRequestObjectResult))]
        [ProducesResponseType(401, Type = typeof(UnauthorizedObjectResult))]
        [HttpPost]
        [Route("login")]
        public IActionResult login([FromBody] LoginDTO login)
        {

            return Ok(_basicService.login(login));
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
        [ProducesResponseType(200, Type = typeof(RegisterDTO))]
        [ProducesResponseType(400, Type = typeof(BadRequestObjectResult))]
        [ProducesResponseType(401, Type = typeof(UnauthorizedObjectResult))]
        [HttpPost]
        [Route("hello")]
        public IActionResult hello([FromBody] LoginDTO login)
        {

            return Ok("hello");
        }

    }
}
