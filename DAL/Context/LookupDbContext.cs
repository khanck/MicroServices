using Microsoft.EntityFrameworkCore;
using Model.Lookups;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public class LookupDbContext : DbContext
    {
        public LookupDbContext(DbContextOptions<CoreDbContext> options) : base(options)
        {
        }

        public DbSet<Gender> Genders { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}
