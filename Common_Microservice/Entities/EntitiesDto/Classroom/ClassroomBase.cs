using System;
using System.Collections.Generic;
using System.Text;

namespace Common_Microservice.EntitiesDto.Classroom
{
    public class ClassroomBase
    {
        public int Id { set; get; }

        public string Name { set; get; }

        public string Adress { set; get; }
    }

    public class CreateClassroomInput : ClassroomBase
    { }

    public class ClassroomsOutput : List<ClassroomBase>
    { }
}
