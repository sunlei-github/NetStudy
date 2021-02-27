using Common_Microservice.EntitiesDto.Classroom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom_Microservice.IRepository
{
    public interface IClassroomRepository
    {
        void Create(CreateClassroomInput input);

        ClassroomsOutput GetList();
    }
}
