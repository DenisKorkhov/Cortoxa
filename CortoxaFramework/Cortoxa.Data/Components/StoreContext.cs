using System;
using Cortoxa.Container.Component;
using Cortoxa.Container.Life;
using Cortoxa.Container.Services;

namespace Cortoxa.Data.Components
{
    public class StoreContext : ILifeTimeContext
    {
        public string DataSource { get; set; }

        public Type StoreClass { get; set; }

        public string Name { get; set; }

        public LifeTime LifeTime { get; set; }

        public Action<IServiceInterception> Interceptor { get; set; }
    }
}