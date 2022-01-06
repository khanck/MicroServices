using Microsoft.EntityFrameworkCore;
using Model.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public class CoreDbContext:DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
        {
        }
        public DbSet<Employees> Employees { get; set; }

        public object Configuration { get; internal set; }
    }
}
