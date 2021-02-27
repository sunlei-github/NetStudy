using System;
using System.Collections.Generic;
using System.Text;

namespace Common_Microservice.EntitiesDto.Student
{
    public class StudentBase
    {
        public int Id { set; get; }

        public string Name { set; get; }

        public int Old { set; get; }

        public DateTime CreateTime { set; get; }
    }

    public class CreateStudentInput : StudentBase
    { }

    public class StudentsOutput : List<StudentBase>
    { }
}
