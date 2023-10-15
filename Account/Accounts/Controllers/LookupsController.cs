using AccountModels.DTO;
using AccountRepository;
using AccountServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts.Controllers
{
    
    [Route("api/lookups")]
    [ApiController]
    public class LookupsController : ControllerBase
    {
        private readonly ILookupsService ILookupsService;
        public LookupsController(ILookupsService ILookupsService)
        {
            this.ILookupsService = ILookupsService;
        }
      
        [HttpGet("getLookupByParentCode")]
        public IActionResult GetLookupByParantCode(string code)
        {
            var result =  ILookupsService.GetLookupsByParantCode(code);
          
            return Ok(result);
        }

    }
}
