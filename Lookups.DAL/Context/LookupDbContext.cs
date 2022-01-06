using Microsoft.EntityFrameworkCore;
using Lookups.Model.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lookups.DAL.Context
{
    public class LookupDbContext : DbContext
    {
        public LookupDbContext(DbContextOptions<LookupDbContext> options) : base(options)
        {
        }

        public DbSet<Gender> Genders { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}
