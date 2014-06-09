using System;
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
        #region Fields

        private readonly ISession session;
        private ITransaction transaction;
        private bool disposed;
        #endregion

        public HibernateDataSource(ISession session)
        {
            this.session = session;
            this.BeginTransaction();
        }

        public void BeginTransaction()
        {
            if (transaction != null)
            {
                throw new Exception("Transaction already initialized");
            }
            transaction = this.session.BeginTransaction();
        }

        public void Commit()
        {
            if (transaction != null && transaction.IsActive)
            {
                try
                {
                    transaction.Commit();
                    
                }
                catch (Exception e)
                {
                    this.Rollback();
                    throw;
                }
                
            }
        }

        public void Rollback()
        {
            if (transaction != null)
            {
                transaction.Rollback();
            }
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
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && !disposed)
            {
                SaveChanges();
                Commit();
                disposed = true;
            }
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