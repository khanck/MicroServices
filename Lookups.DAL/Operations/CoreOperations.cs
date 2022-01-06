using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Lookups.DAL.Context;

namespace Lookups.DAL.Operations
{
    public class CoreOperations<T> : IDisposable where T : class
    {
        private IServiceProvider _serviceProvider;
        protected LookupDbContext context;

        public CoreOperations(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            context = new LookupDbContext(serviceProvider.GetRequiredService<DbContextOptions<LookupDbContext>>());
            DbSet = context.Set<T>();
        }
        protected DbSet<T> DbSet
        {
            get; set;
        }
        public T Add(T obj)
        {
            return DbSet.Add(obj).Entity;
        }
        public T Update(T obj)
        {
            DbSet.Add(obj);
            context.Entry(obj).State = EntityState.Modified;
            return obj;
        }
        public List<T> GetAll()
        {
            return DbSet.ToListAsync().Result;
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public IQueryable<T> GetAllAsQuerable()
        {
            return DbSet.AsQueryable();
        }
        public T GetByID(int id)
        {
            return DbSet.Find(id);
        }
        public async Task<T> GetByIDAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }
        public T Delete(int id)
        {
            T obj = DbSet.Find(id);
            if (obj == null)
                return null;
            return DbSet.Remove(obj).Entity;
        }

        public void SaveChanges()
        {
            context.SaveChanges();

        }
        public void DisableValidationAndSaveChanges()
        {
            context.ChangeTracker.AutoDetectChangesEnabled = false;
            context.SaveChanges();
            context.ChangeTracker.AutoDetectChangesEnabled = true;
        }

        public virtual void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }

        }

    }
}
