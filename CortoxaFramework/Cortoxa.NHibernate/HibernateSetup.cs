#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	HibernateSetup.cs
//  *  Date:		17/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using System.Reflection;
using Cortoxa.Data;
using Cortoxa.Data.IoC;
using Cortoxa.Data.Schema;
using Cortoxa.IoC.Attributes;
using Cortoxa.NHibernate.Data;
using Cortoxa.NHibernate.IoC;
using NHibernate;

namespace Cortoxa.NHibernate
{
    public static class HibernateSetup
    {
        public static IDataConfig UseHibernate(this IToolSetup<IDataConfig> dataSetup, string connectionString, Assembly sourceAssembly, ToolkitLifeTime lifeTime = ToolkitLifeTime.PerWebRequest, bool buildSchema = false)
        {
            Func<IModelBuilder, ISessionFactory> sessionAction = (schemaBuilder) => SessionFactoryConfiguration.BuildSessionFactory(sourceAssembly, connectionString, "", schemaBuilder);
            var dataConfig = new DataConfig(string.Format("h_{0}", Guid.NewGuid().ToString()))
                .WithContext<HibernateContext>(lifeTime)
                .WithRepository(typeof (HibernateRepository<>))
                .WithSession(sessionAction);
            return dataConfig;
        }

        public static IDataConfig WithSession(this IDataConfig config, Func<IModelBuilder, ISessionFactory> sessionAction, ToolkitLifeTime lifeTime = ToolkitLifeTime.Transient)
        {
            config.Configure<SessionConfiguration>(c =>
            {
                c.SessionFactory = sessionAction;
                c.LifeTime = lifeTime;
            });
            return config;
        }
    }
}