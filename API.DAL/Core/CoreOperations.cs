using API.DAL.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
namespace API.DAL.Core
{
    /// <summary>
    /// All core database operations
    ///getting details, adding and modifying existing data in database
    /// </summary>
    /// <typeparam name="T"></typeparam> T is a database object
    public class CoreOperations<T> : IDisposable where T : class
    {
        private IServiceProvider _serviceProvider;
        protected CoreDbContext context;

        public CoreOperations(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            context = new CoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<CoreDbContext>>());
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
        public T GetByID(Guid id)
        {
            return DbSet.Find(id);
        }
        public async Task<T> GetByIDAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }
        public T Delete(Guid id)
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
