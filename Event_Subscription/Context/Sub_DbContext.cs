using Event_Subscription.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Event_Subscription.Context
{
    public class Sub_DbContext : DbContext
    {
        public Sub_DbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public Sub_DbContext()
        {
        }

        public DbSet<Event> Events { set; get; }

    }
}
