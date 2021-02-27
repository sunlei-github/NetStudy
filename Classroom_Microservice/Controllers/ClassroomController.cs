using Classroom_Microservice.IRepository;
using Common_Microservice.EntitiesDto.Classroom;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom_Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ClassroomController : ControllerBase
    {
        private readonly IClassroomRepository _classroomRepository;

        public ClassroomController(IClassroomRepository classroomRepository)
        {
            this._classroomRepository = classroomRepository;
        }

        [HttpPost]
        public void Create(CreateClassroomInput input)
        {
            _classroomRepository.Create(input);
        }

        [HttpGet]
        public JsonResult GetList()
        {
            return new JsonResult(_classroomRepository.GetList());
        }
    }
}
