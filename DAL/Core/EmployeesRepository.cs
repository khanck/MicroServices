using Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Core
{
    public class EmployeesRepository:CoreOperations<Employees> 
    {
        public EmployeesRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
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
