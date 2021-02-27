using Common_Microservice.EntitiesDto.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Microservice.IRepository
{
    public interface IStudentRepository
    {
        void Create(CreateStudentInput input);

        StudentsOutput GetList();

    }
}
