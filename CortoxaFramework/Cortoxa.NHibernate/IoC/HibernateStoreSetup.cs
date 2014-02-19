#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	HibernateStoreSetup.cs
//  *  Date:		19/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using System.Reflection;
using Cortoxa.Data.Context;
using Cortoxa.Data.NHibernate.Data;
using Cortoxa.Data.Repository;
using Cortoxa.IoC;
using Cortoxa.IoC.Attributes;
using Cortoxa.IoC.Registration.Extentions;
using NHibernate;

namespace Cortoxa.Data.NHibernate.IoC
{
    public class HibernateStoreSetup : StoreSetup
    {
        private readonly string connectionString;
        private readonly Assembly sourceAssembly;

        public HibernateStoreSetup(string scope, string connectionString, Assembly sourceAssembly) : base(scope)
        {
            this.connectionString = connectionString;
            this.sourceAssembly = sourceAssembly;
        }

        public override void Register(IToolContainer container)
        {
            var respositoryName = string.Format("repository.{0}", Scope);
            var sessionName = string.Format("session.{0}", Scope);
            var hibernateSessionName = string.Format("hib.session.{0}", Scope);
            var factoryName = string.Format("session.factory.{0}", Scope);

            container.Register(r => r.For<ISessionFactory>().ToFactory(x => SessionFactoryConfiguration.BuildSessionFactory(sourceAssembly, connectionString)).Name(factoryName).LifeTime(ToolkitLifeTime.Singleton));

            container.Register(r => r.For<ISession>().ToFactory(x =>
            {
                var c = container;
                var factory = c.Resolve<ISessionFactory>();
                return factory.OpenSession();
            }).Name(hibernateSessionName).LifeTime(ToolkitLifeTime.Transient));

            container.Register(r => r.For<IDbSession>().To(SessionConfig.Type).Name(sessionName).DependsOn<ISession>(hibernateSessionName).LifeTime(StoreConfig.LifeTime));
            container.Register(r => r.For(typeof(IStore<>)).To(StoreConfig.Type).Name(respositoryName).DependsOn<IDbSession>(sessionName).LifeTime(StoreConfig.LifeTime));
        }
    }
}