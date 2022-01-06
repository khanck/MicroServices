using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Core
{
    public class CommonRepository<T>:CoreOperations<T> where T : class
    {
        public CommonRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
