#region Copyright © 2014 
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
using System.Linq;
using System.Threading.Tasks;
using Cortoxa.Data.EntityFramework.Schema;
using Cortoxa.Data.Schema;

namespace Cortoxa.Data.EntityFramework.Data
{
    public class EntityContext : DbContext
    {
        

        protected EntityContext()
        {
        
        }

        public EntityContext(string nameOrConnectionString): base(nameOrConnectionString)
        {
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        public void BuildModel()
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var modelConfigurator = new EntityModelBuilder(modelBuilder);
            base.OnModelCreating(modelBuilder);
//            if (this.modelBuilder != null)
//            {
//                this.modelBuilder.Build();
//            }
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

//        public new Task SaveChangesAsync()
//        {
//            return Task.Factory.StartNew(SaveChanges);
//        }
    }
}