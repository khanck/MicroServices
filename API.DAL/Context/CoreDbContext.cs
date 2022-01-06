using API.Model.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.DAL.Context
{
    /// <summary>
    /// database context  
    /// </summary>
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
        {
        }
        public DbSet<Employees> Employees { get; set; }

        public object Configuration { get; internal set; }
    }
}
