#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	SessionFactoryConfiguration.cs
//  *  Date:		10/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using System.Linq;
using System.Reflection;
using Cortoxa.Data.Schema;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;

namespace Cortoxa.NHibernate.Data
{
    public static class SessionFactoryConfiguration
    {
        public static ISessionFactory BuildSessionFactory(Assembly sourceAssembly, string connectionString, string providerName = "", IModelBuilder modelBuilder = null)
        {
            var cfg = new Configuration();
            cfg.DataBaseIntegration(c =>
            {
                c.ConnectionStringName = connectionString;
                if (providerName.Equals("System.Data.SqlServerCe.4.0", StringComparison.OrdinalIgnoreCase))
                {
                    c.Driver<SqlServerCeDriver>();
                    c.Dialect<MsSqlCe40Dialect>();
                }
                else
                {
                    c.Driver<SqlClientDriver>();
                    c.Dialect<MsSql2008Dialect>();
                }

                #if DEBUG
                c.LogSqlInConsole = true;
                c.LogFormattedSql = true;
                #endif

                c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;

                c.SchemaAction = SchemaAutoAction.Update;

            });
            cfg.ConfigureMappings(sourceAssembly, modelBuilder);
            return cfg.BuildSessionFactory();
        }

        private static void ConfigureMappings(this Configuration cfg, Assembly sourceAssembly, IModelBuilder modelBuilder)
        {
            var mapper = new ModelMapper();

            var maps = sourceAssembly.GetExportedTypes().Where(t => t.IsClass && !t.IsAbstract).ToArray();
            mapper.AddMappings(maps);

            if (modelBuilder != null)
            {
                modelBuilder.Build();
            }
            cfg.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());
        }
    }
}