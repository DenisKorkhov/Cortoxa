using System;
using Cortoxa.Container.Component;
using Cortoxa.Container.Extentions;
using Cortoxa.Container.Registrator;
using Cortoxa.Data.Common;
using Cortoxa.Data.Components;
using Cortoxa.Data.Repository;

namespace Cortoxa.Data
{
    public static class StoreSetup
    {
        public static IComponentConfigurator<StoreContext> Repository(this IRegistration registration)
        {
            var configurator = new ComponentConfigurator<StoreContext>(registration, new StoreContext());
            configurator.Configure(c => c.StoreClass = typeof(Store<>));
            configurator.Register((r, c) =>
            {
                var name = c.Name;
                if (string.IsNullOrEmpty(name))
                {
                    name = Guid.NewGuid().ToString();
                }
                r.For(typeof(IStore<>)).To(c.StoreClass).DependsOnComponent<IDataSource>(c.DataSource).Name(name).LifeTime(c.LifeTime);
            });
            return configurator;
        }

        public static IComponentConfigurator<StoreContext> Type(this IComponentConfigurator<StoreContext> configurator, Type type)
        {
            if (!type.IsClass)
            {
                throw new Exception("Repository type is not class");
            }

            configurator.Configure(x=>x.StoreClass = type);
            return configurator;
        }

        public static IComponentConfigurator<StoreContext> DataSource(this IComponentConfigurator<StoreContext> configurator, string dataSource)
        {
            configurator.Configure(x => x.DataSource = dataSource);
            return configurator;
        }
    }
}