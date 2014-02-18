#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	HibernateRepository.cs
//  *  Date:		04/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System.Linq;
using Cortoxa.Common;
using Cortoxa.Data;
using Cortoxa.Data.Context;
using Cortoxa.Data.Repository;

namespace Cortoxa.NHibernate.Data
{
    public class HibernateRepository<T> : Store<T> where T : class, IEntity
    {
        public HibernateRepository(IDbContext context) : base(context)
        {
        }

        public override IQueryable<T> GetQuery()
        {
            return Context.Query<T>();
        }

        public override void Add(T entity)
        {
            this.HibernateContext.Session.Save(entity);
            this.HibernateContext.Session.Flush();
        }

        public override void Update(T entity)
        {
            this.HibernateContext.Session.SaveOrUpdate(entity);
            this.HibernateContext.Session.Flush();
        }

        public override void Delete(T entity)
        {
            this.HibernateContext.Session.Delete(entity);
        }

        public HibernateContext HibernateContext
        {
            get
            {
                return (HibernateContext) Context;
            }
        }
    }
}