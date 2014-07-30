#region Copyright © 2014 
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	EntitySetup.cs
//  *  Date:		19/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using System.Data.Entity;
using Cortoxa.Container.Component;
using Cortoxa.Container.Extentions;
using Cortoxa.Container.Life;
using Cortoxa.Data.Common;
using Cortoxa.Data.Components;
using Cortoxa.Data.EntityFramework.Component;
using Cortoxa.Data.EntityFramework.Schema;

namespace Cortoxa.Data.EntityFramework
{
    public static class EntitySetup
    {
        public static IComponentConfigurator<EntityDataContext> UseEnitityFramework(this IComponentSetup<DataSourceContext> setup)
        {
            var configurator = setup.Setup(() => new EntityDataContext()
            {
            }, 
                (r, c) =>
                    {
//                        c.DbContext = r.For<DbContext>().To(c.ContextType);
//                        c.DataSource = r.For<IDataSource, IUnitOfWork>().To<EntityDataSource>();
//                        c.ModelBuilder = r.For<IModelBuilder>().To<EntityModelBuilder>();
//                        c.ModelBuilder.LifeTime(LifeTime.Transient);
//                        c.DbContext.Intercept.After<DbContext>("OnModelCreating", context =>
//                            {
//                                
//                            })
//                            .DependsOnValue("connectionString", c.ConnectionString).LifeTime(c.LifeTime);
//                        c.DataSource.DependsOnComponent<EntityDataSource>("DbContext").LifeTime(c.LifeTime);
                    });
            return configurator;
        }
    }
}