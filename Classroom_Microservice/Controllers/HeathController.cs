using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom_Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]/[Action]")]
    public class HeathController : ControllerBase
    {

        [HttpGet]
        public ActionResult Check()
        {
            Console.WriteLine("心跳检查");
            return Ok();
        }
    }
}
