#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	EntityStoreSetup.cs
//  *  Date:		19/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using System;
using System.Data.Entity;
using Cortoxa.Data.Context;
using Cortoxa.Data.Repository;
using Cortoxa.IoC;
using Cortoxa.IoC.Base;

namespace Cortoxa.Data.EntityFramework.IoC
{
    public class EntityStoreSetup : StoreSetup
    {
        public EntityStoreSetup(string scope, Type contextType): base(scope)
        {
        }

        public override void Register(IToolContainer container)
        {
//            container.Register(r => r.For<DbContext>().ToFactory(x => null).LifeTime(LifeTime.Transient));
//
//            var respositoryName = string.Format("repository.{0}", Scope);
//            var sessionName = string.Format("session.{0}", Scope);
//
//            container.Register(r => r.For(typeof(IStore<>)).To(StoreConfig.Type).Name(respositoryName).DependsOn<IDbSession>(sessionName).LifeTime(StoreConfig.LifeTime));
//            container.Register(r => r.For<IDbSession>().To(SessionConfig.Type).Name(sessionName).LifeTime(StoreConfig.LifeTime));

//            base.Register(container);
        }
    }
}