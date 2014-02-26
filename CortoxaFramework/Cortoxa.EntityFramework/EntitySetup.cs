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
using Cortoxa.IoC.Base;

namespace Cortoxa.Data.EntityFramework
{
    public static class EntitySetup
    {
        public static IToolComponent<IDataComponent> EntityDataSource<TContext>(this IToolComponent<IDataComponent> toolComponent, LifeTime lifetTime = LifeTime.Transient) where TContext : DbContext
        {
            toolComponent.Add(s => s.For<DbContext>().To<TContext>().LifeTime(lifetTime));
            toolComponent.Add(s => s.For<IDataSource, IUnitOfWork>().To<EntityDataSource>().LifeTime(lifetTime));
            return toolComponent;
        }
    }
}