using System;
using Cortoxa.Container.Component;
using Cortoxa.Container.Life;

namespace Cortoxa.Data.Components
{
    public class StoreContext : ILifeTimeContext
    {
        public string DataSource { get; set; }

        public Type StoreClass { get; set; }

        public string Name { get; set; }

        public LifeTime LifeTime { get; set; }
    }
}