using System;
using Cortoxa.Container.Component;

using Cortoxa.Container.Registrator;

namespace Cortoxa.Data.Components
{
    public static class DataExtentions
    {
        public static IRegistration DataAccess(this IRegistration registration, Action<IComponentSetup<DataSourceContext>> setupAction)
        {
            var setup = new ComponentSetup<DataSourceContext>(registration);
            setupAction(setup);
            setup.Build(); 
            return registration;
        }

        public static IComponentConfigurator<T> ConnectionString<T>(this IComponentConfigurator<T> configurator, string connectionString) where T : DataSourceContext
        {
            configurator.Configure(c=>c.ConnectionString = connectionString);
            return configurator;
        }

        public static void Repository(this IRegistration registration)
        {
//            var configurator = new ComponentConfigurator<RepositoryConfig>(registration);
//            configurator.Configure(c => c.LifeTime = lifeTime);
//            configurator.Configure(c => c.DataSource = dataSource);
//            configurator.ConfigureBuild((c) => registration.For(new[] { typeof(IStore<>) }).To(typeof(Store<>)).DependsOnComponent<IDataSource>(c.DataSource).LifeTime(c.LifeTime));
//            configurator.Build();
//            return registration;
            throw new NotImplementedException();
        }
    }
}
