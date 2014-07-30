#region Copyright © 2014 
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	HibernateContext.cs
//  *  Date:		04/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;

namespace Cortoxa.Data.NHibernate.Data
{
    public class HibernateContext //: IDbContext
    {
        private readonly ISession session; 
        
        public HibernateContext(ISession session)
        {
            this.session = session;
        } 
        
        public void Dispose()
        {
            session.Dispose();
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            return session.Query<TEntity>();
        }

        public void BuildModel()
        {
        }

        public void OnBuildSchama()
        {
            
        }

        public void SaveChanges()
        {
            session.Flush();
        }

        public async Task SaveChangesAsync()
        {
            await Task.Run(() => session.Flush()).ConfigureAwait(false);
        } 

        public ISession Session
        {
            get
            {
                return session;
            }
        } 
    }
}