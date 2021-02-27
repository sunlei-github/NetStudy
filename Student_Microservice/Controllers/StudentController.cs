using Common_Microservice.EntitiesDto.Student;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Student_Microservice.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Student_Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }


        [HttpPost]
        public ActionResult Create(CreateStudentInput input)
        {
            _studentRepository.Create(input);
            return Ok();
        }

        [HttpGet]
        public JsonResult GetList()
        {
            return new JsonResult(_studentRepository.GetList());
        }

        [HttpGet]
        public ActionResult PollyTimeOut()
        {
            Thread.Sleep(1000000000);
            return new JsonResult("返回的数据");
        }
    }
}
