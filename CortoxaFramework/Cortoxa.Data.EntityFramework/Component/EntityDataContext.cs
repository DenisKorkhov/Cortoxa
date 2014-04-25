using System;
using Cortoxa.Container.Services;
using Cortoxa.Data.Components;

namespace Cortoxa.Data.EntityFramework.Component
{
    public class EntityDataContext : DataSourceContext
    {
        public Type ContextType { get; set; }

        public IServiceConfigurator DbContext { get; set; }
    }
}