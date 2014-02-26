#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	EntitySession.cs
//  *  Date:		19/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Cortoxa.Data.Common;
using Cortoxa.Data.Context;

namespace Cortoxa.Data.EntityFramework.Context
{
    public class EntitySession : IDbSession
    {
        private readonly DbContext context;

        public EntitySession(DbContext context)
        {
            this.context = context;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return Task.Run(() => SaveChanges());
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.SaveChanges();
                context.Dispose();
            }
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
            context.Set<TEntity>().Add(value);
        }
    }
}