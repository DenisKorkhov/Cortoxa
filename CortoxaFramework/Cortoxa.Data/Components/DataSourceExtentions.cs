using Cortoxa.Container.Component;

namespace Cortoxa.Data.Components
{
    public static class DataSourceExtentions
    {
        public static IComponentConfigurator<DataSourceContext> ConnectionString(this IComponentConfigurator<DataSourceContext> configurator, string connectionString)
        {
            configurator.Configure(x => x.ConnectionString = connectionString);
            return configurator;
        }
    }
}