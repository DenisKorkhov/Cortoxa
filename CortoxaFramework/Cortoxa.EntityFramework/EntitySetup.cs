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
using Cortoxa.Components;
using Cortoxa.Data.Component;
using Cortoxa.Data.EntityFramework.Component;
using Cortoxa.IoC;
using Cortoxa.IoC.Base;

namespace Cortoxa.Data.EntityFramework
{
    public static class EntitySetup
    {
        public static IToolComponent<EntityComponent> EntityDataSource<TContext>(this IComponentSetup toolComponent) where TContext : DbContext
        {
            var component = new ToolComponent<EntityComponent>();
            component.Configure(c=>c.DbContext.For<DbContext>().To<TContext>().LifeTime(LifeTime.PerWebRequest));
            component.Configure(c=>c.DbContext.For<IDataSource, IUnitOfWork>().To<EntityDataSource>().LifeTime(LifeTime.PerWebRequest));
//            component.Register();
            return null;
        }
    }
}