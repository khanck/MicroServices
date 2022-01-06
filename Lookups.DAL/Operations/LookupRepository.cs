using System;
using System.Collections.Generic;
using System.Text;

namespace Lookups.DAL.Operations
{
    public class LookupRepository<T> : CoreOperations<T> where T : class
    {
        public LookupRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
