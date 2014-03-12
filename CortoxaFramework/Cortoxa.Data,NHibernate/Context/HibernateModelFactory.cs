#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	HibernateModelFactory.cs
//  *  Date:		19/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using System;
using System.Linq;
using System.Reflection;
using Cortoxa.Data.Context;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;

namespace Cortoxa.Data.NHibernate.Context
{
    public class HibernateModelFactory : IModelFactory<ISessionFactory>
    {
        private readonly string connectionString;
        private readonly string providerName;
        private readonly Assembly assembly;
        private readonly bool buildSchema;
        private readonly Configuration configuration;

        public HibernateModelFactory(string connectionString, string providerName, Assembly assembly, bool buildSchema)
        {
            this.connectionString = connectionString;
            this.providerName = providerName;
            this.assembly = assembly;
            this.buildSchema = buildSchema;
            this.configuration = new Configuration();
        }

        public virtual void Configure()
        {
            configuration.DataBaseIntegration(c =>
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

                if (buildSchema)
                {
                    c.SchemaAction = SchemaAutoAction.Update;
                }
            });
        }

        public ISessionFactory GetSession()
        {
            this.Configure();
            this.BuildModel();
            return configuration.BuildSessionFactory();
        }

        public virtual void BuildModel()
        {
            var mapper = new ModelMapper();
            var maps = assembly.GetExportedTypes().Where(t => t.IsClass && !t.IsAbstract).ToArray();
            mapper.AddMappings(maps);
            configuration.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());
        }
    }
}