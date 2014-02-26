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
using Cortoxa.Data.Repository;
using Cortoxa.IoC.Base;
using Cortoxa.IoC.Service;

namespace Cortoxa.Data.EntityFramework
{
    public static class EntitySetup
    {

        public static IToolComponent<IDataSource> EntityDataSource<TContext>(this IToolComponent<IDataSource> toolComponent, LifeTime lifetTime = LifeTime.Transient) where TContext : DbContext
        {
            var contextName = string.Format("context_{0}", "");

//            toolComponent.AddRegistration();

            toolComponent.OnRegister(x => x
                .Service<DbContext>(s => s.To<TContext>().LifeTime(lifetTime))
                .Service<IDataSource, IUnitOfWork>(s => s.To<EntityDataSource>().LifeTime(lifetTime).DependOn(typeof(DbContext), ""))
                .Service(s => s.To(typeof(Store<>)).Transient(), typeof(IStore<>))
            );
            return toolComponent;
        }
    }
}