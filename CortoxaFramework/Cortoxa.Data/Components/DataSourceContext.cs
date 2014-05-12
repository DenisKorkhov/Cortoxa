using System;
using Cortoxa.Container.Component;
using Cortoxa.Container.Life;
using Cortoxa.Container.Services;

namespace Cortoxa.Data.Components
{
    public class DataSourceContext : ILifeTimeContext
    {
        public string ConnectionString { get; set; }

        public string Name { get; set; }

        public string Provider { get; set; }

        public LifeTime LifeTime { get; set; }

        public Type DbContext { get; set; }

        public string ModelBuilder { get; set; }
    }
}