using System.Data.Entity;
using Cortoxa.Container.Component;

namespace Cortoxa.Data.EntityFramework.Component
{
    public static class DataSourceExtentions
    {
        public static IComponentConfigurator<EntityDataContext> Context<T>(this IComponentConfigurator<EntityDataContext> configurator) where T : DbContext
        {
            configurator.Configure(c => c.ContextType = typeof(T));
            return configurator;
        }
    }
}