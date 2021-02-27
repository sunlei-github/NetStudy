using Common_Microservice.Entities.Entities.Student;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Microservice.Context
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext():base() { }

        public StudentDbContext(DbContextOptions options) : base(options) { }

        public DbSet<DbStudent> DbStudents { set; get; }
    }
}
