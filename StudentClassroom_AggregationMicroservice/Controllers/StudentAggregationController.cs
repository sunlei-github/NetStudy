using Consul;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentClassroom_AggregationMicroservice.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentClassroom_AggregationMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StudentAggregationController : ControllerBase
    {
        private readonly IStudentClientService _studentClientService = null;

        public StudentAggregationController(IStudentClientService studentClientService)
        {
            _studentClientService = studentClientService;
        }

        [HttpGet]
        public ActionResult Create()
        {
            _studentClientService.Create();

            return Ok();
        }

        [HttpGet]
        public ActionResult GetList()
        {
            string result = _studentClientService.GetList();

            return new JsonResult(result);
        }

        [HttpGet]
        public ActionResult PollyTimeOut()
        {
            _studentClientService.PollyTimeOut();

            return Ok();
        }
    }
}
