using System;
using Cortoxa.Container.Component;
using Cortoxa.Data.Components;
using NHibernate.Cfg.Loquacious;

namespace Cortoxa.Data.NHibernate.Container
{
    public class HibernateDataContext : DataSourceContext, ILifeTimeContext
    {
        public bool BuildSchema { get; set; }
        public bool UpdateSchema { get; set; }
        public Action<IDbIntegrationConfigurationProperties> ConfigurationAction { get; set; }
    }
}
