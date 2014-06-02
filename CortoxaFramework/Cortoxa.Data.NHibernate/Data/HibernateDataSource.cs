using System.Linq;
using System.Threading.Tasks;
using Cortoxa.Data.Common;
using Cortoxa.Data.Model;
using NHibernate;
using NHibernate.Linq;

namespace Cortoxa.Data.NHibernate.Data
{
    public class HibernateDataSource : IDataSource
    {
        private readonly ISession session;

        public HibernateDataSource(ISession session)
        {
            this.session = session;
        }

        public void SaveChanges()
        {
            session.Flush();
        }

        public async Task SaveChangesAsync()
        {
            await Task.Run(() => session.Flush()).ConfigureAwait(false);
        }

        public void Dispose()
        {
            this.session.Dispose();
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class, IEntity
        {
            return this.session.Query<TEntity>();
        }

        public void Add<TEntity>(TEntity value) where TEntity : class, IEntity
        {
            this.session.SaveOrUpdate(value);
        }

        public void Update<TEntity>(TEntity value) where TEntity : class, IEntity
        {
            this.session.Update(value);
        }

        public void Delete<TEntity>(TEntity value) where TEntity : class, IEntity
        {
            this.session.Delete(value);
        }

        public ISession Session
        {
            get { return session; }
        }
    }
}