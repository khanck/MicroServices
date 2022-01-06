using API.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.DAL.Core
{
    /// <summary>
    /// All database operation for Employee table 
    /// </summary>
    public class EmployeesRepository : CoreOperations<Employees>
    {
        public EmployeesRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
        // additional functions other than core operations functions 
        public bool IsAlreadyExists(Employees employees)
        {
            return DbSet.Any(o => o.Email == employees.Email);
        }
        public bool IsAlreadyExistsInOther(Employees employees)
        {
            return DbSet.Any(o => o.Email == employees.Email && o.ID != employees.ID);
        }
    }
}
