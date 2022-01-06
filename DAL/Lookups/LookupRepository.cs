using Model.Lookups;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Core;

namespace DAL.Lookups
{
   public class LookupRepository<T> : CoreOperations<T> where T : class
    {
        public LookupRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
