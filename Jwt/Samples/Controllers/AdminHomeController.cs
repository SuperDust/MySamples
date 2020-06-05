using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Samples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(policy: "AdminOrSystem")]
    public class AdminHomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("AdminOrSystem");
        }
    }
}