using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Event_Publish.Context
{
    public class Pub_DbContext : DbContext
    {
        public Pub_DbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public Pub_DbContext()
        {
        }
    }
}
