#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	EntityContext.cs
//  *  Date:		10/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using Cortoxa.Data.Context;
using Cortoxa.Data.Schema;

namespace Cortoxa.Data.EntityFramework.Data
{
    public class EntityContext : DbContext//, IDbContext
    {
        private readonly IModelBuilder modelBuilder;

        protected EntityContext(IModelBuilder modelBuilder = null)
        {
            this.modelBuilder = modelBuilder;
        }

        public EntityContext(string nameOrConnectionString, IModelBuilder modelBuilder = null): base(nameOrConnectionString)
        {
            this.modelBuilder = modelBuilder;
        }

        public EntityContext(string nameOrConnectionString, DbCompiledModel model, IModelBuilder modelBuilder = null): base(nameOrConnectionString, model)
        {
            this.modelBuilder = modelBuilder;
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        public void BuildModel()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            if (this.modelBuilder != null)
            {
                this.modelBuilder.Build();
            }
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new Task SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}