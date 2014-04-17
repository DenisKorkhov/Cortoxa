using System;
using System.Linq;
using Cortoxa.Data.Model;

namespace Cortoxa.Data.Common
{
    public interface IDataSource : IUnitOfWork, IDisposable 
    {
        IQueryable<TEntity> Query<TEntity>() where TEntity : class, IEntity;

        void Add<TEntity>(TEntity value) where TEntity : class, IEntity;

        void Update<TEntity>(TEntity value) where TEntity : class, IEntity;

        void Delete<TEntity>(TEntity value) where TEntity : class, IEntity; 
    }
}