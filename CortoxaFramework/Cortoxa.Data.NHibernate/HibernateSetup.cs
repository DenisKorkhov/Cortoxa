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
using System.Linq;
using System.Reflection;
using Cortoxa.Container.Component;
using Cortoxa.Container.Extentions;
using Cortoxa.Container.Life;
using Cortoxa.Container.Registrator;
using Cortoxa.Data.Common;
using Cortoxa.Data.NHibernate.Container;
using Cortoxa.Data.NHibernate.Data;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;

namespace Cortoxa.Data.NHibernate
{
    public static class HibernateSetup
    {
        public static IComponentConfigurator<HibernateDataContext> HibernateDataSource<T>(this IRegistration registration, LifeTime lifeTime = LifeTime.Transient)
        {
            var configurator = new ComponentConfigurator<HibernateDataContext>(registration);

            #region Configure default values
            configurator.Configure(c => c.LifeTime = lifeTime);
            configurator.Configure(c => c.DbContext = typeof(T)); 
            #endregion

            configurator.Register((r, c) =>
            {
                var name = c.Name;

                if (string.IsNullOrEmpty(name))
                {
                    name = Guid.NewGuid().ToString();
                }

                var dataSourceNameSet = string.Format("{0}_hdatasource", name);
                var sessionFactoryName = string.Format("{0}_sessionfactory", dataSourceNameSet);
                var sessionName = string.Format("{0}_session", dataSourceNameSet);

                r.For<ISessionFactory>().ToFactory(fc => GetSessionFactory(c)).Name(sessionFactoryName).LifeTime(LifeTime.Singleton);
                r.For<ISession>().ToFactory((fc, resolver) =>
                {
                    var factoryName = sessionFactoryName;
                    var factory = resolver.Resolve<ISessionFactory>(factoryName);
                    return factory.OpenSession();
                }).DependsOnComponent<ISessionFactory>(sessionFactoryName).Name(sessionName).LifeTime(c.LifeTime);

                r.For<IDataSource>().To<HibernateDataSource>().DependsOnComponent<ISession>(sessionName).Name(name).LifeTime(c.LifeTime);
            });
            return configurator;
        }

        public static ISessionFactory GetSessionFactory(HibernateDataContext cotnext)
        {
            var cfg = new global::NHibernate.Cfg.Configuration();
            cfg.DataBaseIntegration(c =>
            {
                c.ConnectionStringName = cotnext.ConnectionString;
                if (cotnext.Provider != null && cotnext.Provider.Equals("System.Data.SqlServerCe.4.0", StringComparison.OrdinalIgnoreCase))
                {
                    c.Driver<SqlServerCeDriver>();
                    c.Dialect<MsSqlCe40Dialect>();
                }
                else
                {
                    c.Driver<SqlClientDriver>();
                    c.Dialect<MsSql2012Dialect>();
                }
                
                #if DEBUG
//                c.LogSqlInConsole = true;
                c.LogFormattedSql = true;
                #endif
                c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                c.SchemaAction = SchemaAutoAction.Update;

            });

            var mapper = new ModelMapper();
            MapModels(mapper, cotnext.DbContext);
            cfg.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());
            var result =  cfg.BuildSessionFactory();
            if (cotnext.BuildSchema)
            {
                BuildSchema(cfg);
            }
            return result;
        }

        public static IComponentConfigurator<HibernateDataContext> BuildSchema(this IComponentConfigurator<HibernateDataContext> configurator)
        {
            configurator.Configure(c => c.BuildSchema = true);
            return configurator;
        }

        private static void BuildSchema(global::NHibernate.Cfg.Configuration cfg)
        {
            var export = new SchemaExport(cfg);
            export.Create(false, true);
        }

        private static void MapModels(ModelMapper mapper, Type contextType)
        {
            var publicTypes = contextType.GetProperties().Select(x=>x.PropertyType).Distinct().ToList();
            mapper.AddMappings(publicTypes);
        }
    }
}