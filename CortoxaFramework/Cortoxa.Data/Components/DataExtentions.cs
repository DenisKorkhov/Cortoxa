using System;
using Cortoxa.Container.Component;

using Cortoxa.Container.Registrator;

namespace Cortoxa.Data.Components
{
    public static class DataExtentions
    {
        public static IRegistration DataSource(this IRegistration registration, Action<IComponentSetup<DataSourceContext>> setupAction)
        {
            var setup = new ComponentSetup<DataSourceContext>(registration);
            setupAction(setup);
            setup.Build(); 
            return registration;
        }

        public static IComponentConfigurator<StoreContext> DataStore<T>(this IComponentConfigurator<T> configurator) where T : DataSourceContext
        {
            return configurator.Child(new StoreContext(), (d, identity) =>
            {
                
            });
        }

        public static IRegistration DataStore(this IRegistration registration, Action<IComponentSetup<StoreContext>> setupAction)
        {
            var setup = new ComponentSetup<StoreContext>(registration);
            setupAction(setup);
            setup.Build();
            return registration;
        }

        public static IComponentConfigurator<T> ConnectionString<T>(this IComponentConfigurator<T> configurator, string connectionString) where T : DataSourceContext
        {
            configurator.Configure(c=>c.ConnectionString = connectionString);
            return configurator;
        }

//        public static IComponentConfigurator<T> ConnectionString<T>(this IComponentConfigurator<T> configurator, string connectionString) where T : DataSourceContext
//        {
//            configurator.Configure(c => c.ConnectionString = connectionString);
//            return configurator;
//        }
    }
}
