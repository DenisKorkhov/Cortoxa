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
using Cortoxa.Data.Model;

namespace Cortoxa.Data.Repository
{
    public class Store<T> : IStore<T> where T : class, IEntity
    {
        private IDataSource session;

        public Store(IDataSource session)
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
            return new Task<T>(() => First(predicate));
        }

        public virtual Task<T> SingleAsync(Expression<Func<T, bool>> predicate)
        {
            return new Task<T>(() => Single(predicate));
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
            return new Task<IEnumerable<T>>(() => FindAll(predicate));
        }

        public virtual IEnumerable<T> GetAll()
        {
            return GetQuery().ToList();
        }

        public virtual void Add(T entity)
        {
            session.Add(entity);
        }

        public Task AddAsync(T entity)
        {
            #if NET40
            return Task.Factory.StartNew(() => Add(entity));
            #else
            return Task.Run(() => Add(entity));
            #endif
        }

        public virtual void Update(T entity)
        {
            session.Update(entity);
        }

        public virtual Task UpdateAsync(T entity)
        {
            #if NET40
            return Task.Factory.StartNew(() => Update(entity));
            #else
            return Task.Run(() => Add(entity));
            #endif
        }

        public virtual void Delete(T entity)
        {
            session.Delete(entity);
        }

        public Task DeleteAsync(T entity)
        {
            #if NET40
            return Task.Factory.StartNew(() => Delete(entity));
            #else
            return Task.Run(() => Add(entity));
            #endif
        }

        public virtual T Get(Guid id)
        {
            return GetQuery().FirstOrDefault(x=>x.Id == id);
        }

        public virtual Task<T> GetAsync(Guid id)
        {
            return new Task<T>(() => Get(id));
        }

        public virtual T[] Get(params Guid[] ids)
        {
            return GetQuery().Where(x => ids.Contains(x.Id)).ToArray();
        }

        public virtual Task<T[]> GetAsync(params Guid[] ids)
        {
            return new Task<T[]>(() => Get(ids));
        }

        public void SaveChanges()
        {
            this.session.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return this.session.SaveChangesAsync();
        }
    }
}