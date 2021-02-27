using Common_Microservice.Entities.Entities.Classroom;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom_Microservice.Context
{
    public class ClassroomDbContext:DbContext
    {
        public ClassroomDbContext() : base() { }

        public ClassroomDbContext(DbContextOptions options) : base(options) { }

        public DbSet<DbClassroom> DbClassrooms { set; get; }
    }
}
