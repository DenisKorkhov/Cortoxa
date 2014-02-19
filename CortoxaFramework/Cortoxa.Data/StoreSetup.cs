#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	StoreSetup.cs
//  *  Date:		19/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using System;
using Cortoxa.Data.Context;
using Cortoxa.Data.IoC;
using Cortoxa.Data.Repository;
using Cortoxa.IoC;
using Cortoxa.IoC.Attributes;
using Cortoxa.IoC.Common;

namespace Cortoxa.Data
{
    public class StoreSetup : IStoreSetup
    {
        private readonly string scope;
        private RepositoryConfiguration storeConfig;
        private SessionConfiguration sessionConfig;

        protected StoreSetup(string scope)
        {
            this.scope = scope;
        }

        public RepositoryConfiguration StoreConfig
        {
            get { return storeConfig; }
        }

        public SessionConfiguration SessionConfig
        {
            get { return sessionConfig; }
        }

        public string Scope
        {
            get { return scope; }
        }

        public virtual IStoreSetup WithSession<T>(ToolkitLifeTime lifeTime = ToolkitLifeTime.Transient) where T : IDbSession
        {
            sessionConfig = new SessionConfiguration(typeof(T), lifeTime);
            return this;
        }


        public IStoreSetup WithRepository(Type type, ToolkitLifeTime lifeTime = ToolkitLifeTime.Transient)
        {
            storeConfig = new RepositoryConfiguration(type, lifeTime);
            return this;
        }

        public virtual void Register(IToolContainer container)
        {
            var respositoryName = string.Format("repository.{0}", scope);
            var sessionName = string.Format("session.{0}", scope);

            container.Register(r => r.For(typeof(IStore<>)).To(storeConfig.Type).Name(respositoryName).DependsOn<IDbSession>(sessionName).LifeTime(storeConfig.LifeTime));
            container.Register(r => r.For<IDbSession>().To(sessionConfig.Type).Name(sessionName).LifeTime(storeConfig.LifeTime));
        }
    }
}