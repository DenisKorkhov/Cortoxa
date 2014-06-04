using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Cortoxa.Data.Common;
using Cortoxa.Data.Model;

namespace Cortoxa.Data.EntityFramework.Component
{
    public class EntityDataSource : IDataSource
    {
        private readonly DbContext context;

        public EntityDataSource(DbContext context)
        {
            this.context = context;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class, IEntity
        {
            return context.Set<TEntity>();
        }

        public void Add<TEntity>(TEntity value) where TEntity : class, IEntity
        {
            context.Set<TEntity>().Add(value);
        }

        public void Update<TEntity>(TEntity value) where TEntity : class, IEntity
        {
            var entry = context.Entry(value);
            if (entry.State == EntityState.Detached)
            {
                context.Set<TEntity>().Attach(value);
                entry.State = EntityState.Modified;
            }
        }

        public void Delete<TEntity>(TEntity value) where TEntity : class, IEntity
        {
            context.Set<TEntity>().Remove(value);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            #if NET40
            return Task.Factory.StartNew(SaveChanges);
            #else
            return Task.Run(() => SaveChanges());
            #endif
        }

        public void BeginTransaction()
        {
            
        }

        public void Commit()
        {

        }

        public void Rollback()
        {

        }
    }
}