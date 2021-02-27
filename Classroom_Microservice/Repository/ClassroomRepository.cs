using Classroom_Microservice.Context;
using Classroom_Microservice.IRepository;
using Common_Microservice.Entities.Entities.Classroom;
using Common_Microservice.EntitiesDto.Classroom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom_Microservice.Repository
{
    public class ClassroomRepository : IClassroomRepository
    {
        private readonly ClassroomDbContext _context;

        public ClassroomRepository(ClassroomDbContext context)
        {
            this._context = context;
        }
        public void Create(CreateClassroomInput input)
        {
            DbClassroom dbClassroom = new DbClassroom
            {
                Adress = input.Adress,
                Name = input.Adress
            };
            _context.DbClassrooms.Add(dbClassroom);
        }

        public ClassroomsOutput GetList()
        {
            var dbClassrooms = _context.DbClassrooms.ToList();

            ClassroomsOutput output = new ClassroomsOutput();

            foreach (var dbClassroom in dbClassrooms)
            {
                ClassroomBase classroom = new ClassroomBase
                {
                    Id = dbClassroom.Id,
                    Name = dbClassroom.Name,
                    Adress=dbClassroom.Adress
                };

                output.Add(classroom);
            }

            return output;
        }
    }
}
