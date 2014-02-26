#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	HibernateSession.cs
//  *  Date:		19/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using System.Linq;
using System.Threading.Tasks;
using Cortoxa.Data.Common;
using Cortoxa.Data.Context;
using Cortoxa.Data.Model;
using NHibernate;
using NHibernate.Linq;

namespace Cortoxa.Data.NHibernate.Context
{
    public class HibernateSession : IDbSession
    {
        private readonly ISession session;

        public HibernateSession(ISession session)
        {
            this.session = session;
        }

        public void SaveChanges()
        {
            this.session.Flush();
        }

        public Task SaveChangesAsync()
        {
            return Task.Run(() => SaveChanges());
        }

        public void Dispose()
        {
            if (session != null && session.IsOpen)
            {
                session.Close();
                session.Dispose();
            }
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class, IEntity
        {
            return session.Query<TEntity>();
        }

        public void Add<TEntity>(TEntity value) where TEntity : class, IEntity
        {
            session.SaveOrUpdate(value);
        }

        public void Update<TEntity>(TEntity value) where TEntity : class, IEntity
        {
            session.Update(value);
        }

        public void Delete<TEntity>(TEntity value) where TEntity : class, IEntity
        {
            session.Delete(value);
        }
    }
}