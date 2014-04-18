using System;
using Cortoxa.Container.Component;
using Cortoxa.Container.Life;
using Cortoxa.Container.Registrator;
using Cortoxa.Data.Common;
using Cortoxa.Data.Repository;

namespace Cortoxa.Data.Components
{
    public static class DataExtentions
    {
        public static IRegistration DataSource(this IRegistration registration, Action<IComponentRegistrator<DataSourceContext>> setup)
        {
            var configurator = new ComponentConfigurator<DataSourceContext>(registration);
            setup(configurator);
            configurator.Build();
            return registration;
        }

        public static IRegistration Repository(this IRegistration registration, string dataSource, LifeTime lifeTime = LifeTime.Transient)
        {
            var configurator = new ComponentConfigurator<RepositoryContext>(registration);
            configurator.Configure(c => c.LifeTime = lifeTime);
            configurator.Configure(c => c.DataSource = dataSource);
            configurator.ConfigureBuild((c) => registration.For(new[] { typeof(IStore<>) }).To(typeof(Store<>)).DependsOnComponent<IDataSource>(c.DataSource).LifeTime(c.LifeTime));
            configurator.Build();
            return registration;
        }
    }
}
