using Common_Microservice.Entities.Entities.Student;
using Common_Microservice.EntitiesDto.Student;
using Student_Microservice.Context;
using Student_Microservice.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Student_Microservice.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _context;

        public StudentRepository(StudentDbContext context)
        {
            this._context = context;
        }

        public void Create(CreateStudentInput input)
        {
            DbStudent student = new DbStudent
            {
                Name = input.Name,
                Old = input.Old
            };

            _context.DbStudents.Add(student);
        }

        public StudentsOutput GetList()
        {
            var dbStudents = _context.DbStudents.ToList();

            StudentsOutput output = new StudentsOutput();

            foreach (var dbStudent in dbStudents)
            {
                StudentBase student = new StudentBase
                {
                    CreateTime = dbStudent.CreateTime,
                    Id = dbStudent.Id,
                    Name = dbStudent.Name,
                    Old = dbStudent.Old
                };

                output.Add(student);
            }

            return output;
        }

        public string TestTimeout()
        {
            Thread.Sleep(1000000);

            return "这是一条测试数据";
        }
    }
}
