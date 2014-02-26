#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	Store.cs
//  *  Date:		11/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Cortoxa.Data.Common;
using Cortoxa.Data.Context;
using Cortoxa.Data.Model;

namespace Cortoxa.Data.Repository
{
    public class Store<T> : IStore<T> where T : class, IEntity
    {
        private IDbSession session;

        public Store(IDbSession session)
        {
            this.session = session;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (session != null)
                {
                    session.Dispose();
                    session = null;
                }
            }
        }

        public virtual IQueryable<T> GetQuery()
        {
            return session.Query<T>();
        }

        public virtual T First(Expression<Func<T, bool>> predicate)
        {
            return GetQuery().FirstOrDefault(predicate);
        }

        public virtual Task<T> FirstAsync(Expression<Func<T, bool>> predicate)
        {
            return Task.FromResult(First(predicate));
        }

        public virtual Task<T> SingleAsync(Expression<Func<T, bool>> predicate)
        {
            return Task.FromResult(Single(predicate));
        }

        public virtual T Single(Expression<Func<T, bool>> predicate)
        {
            return GetQuery().SingleOrDefault(predicate);
        }

        public virtual IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            return GetQuery().Where(predicate).ToList();
        }

        public virtual Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            return Task.FromResult(FindAll(predicate));
        }

        public virtual IEnumerable<T> GetAll()
        {
            return GetQuery().ToList();
        }

        public virtual void Add(T entity)
        {
            session.Delete(entity);
        }

        public Task AddAsync(T entity)
        {
            return Task.Run(() => Add(entity));
        }

        public virtual void Update(T entity)
        {
            session.Update(entity);
        }

        public virtual Task UpdateAsync(T entity)
        {
            return Task.Run(() => Update(entity));
        }

        public virtual void Delete(T entity)
        {
            session.Delete(entity);
        }

        public Task DeleteAsync(T entity)
        {
            return Task.Run(() => Delete(entity));
        }

        public virtual void SaveChanges()
        {
            session.SaveChanges();
        }

        public virtual T Get(Guid id)
        {
            return GetQuery().FirstOrDefault(x=>x.Id == id);
        }

        public virtual Task<T> GetAsync(Guid id)
        {
            return Task.FromResult(Get(id));
        }

        public virtual T[] Get(params Guid[] ids)
        {
            return GetQuery().Where(x => ids.Contains(x.Id)).ToArray();
        }

        public virtual Task<T[]> GetAsync(params Guid[] ids)
        {
            return Task.FromResult(Get(ids));
        }
    }
}