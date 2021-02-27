using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]/[Action]")]
    public class HeathController : ControllerBase
    {

        /// <summary>
        /// 健康检查的Api
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Check()
        {
            Console.WriteLine("触发健康检查");
            return Ok();
        }
    }
}
