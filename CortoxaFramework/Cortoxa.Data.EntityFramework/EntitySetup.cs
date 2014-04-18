#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
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
using Cortoxa.Data.Common;
using Cortoxa.Data.Components;
using Cortoxa.Data.EntityFramework.Component;

namespace Cortoxa.Data.EntityFramework
{
    public static class EntitySetup
    {

//        public static void UseEnitityFramework<T>(this Action<ComponentConfigurator<DataSourceContext>> configurator, string connectionString, LifeTime lifeTime = LifeTime.Transient) where T : DbContext
//        {
//        }

        public static IComponentConfigurator<DataSourceContext> UseEnitityFramework<T>(this IComponentRegistrator<DataSourceContext> configurator/*, string connectionString, LifeTime lifeTime = LifeTime.Transient*/) where T : DbContext
        {
            configurator.Register((r, c) =>
            {
                r.For<DbContext>().To<T>().DependsOnValue("connectionString", c.ConnectionString).LifeTime(c.LifeTime);
                r.For<IDataSource, IUnitOfWork>().To<EntityDataSource>().DependsOnComponent<EntityDataSource>("DbContext").LifeTime(c.LifeTime);
            });

            return configurator;
        }
    }
}