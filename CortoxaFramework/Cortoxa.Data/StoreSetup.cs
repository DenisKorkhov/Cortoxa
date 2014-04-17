using Cortoxa.Container.Component;
using Cortoxa.Container.Life;
using Cortoxa.Data.Components;

namespace Cortoxa.Data
{
    public static class StoreSetup
    {
//        public static void UseEnitityFramework<T>(this IComponentConfigurator<RepositoryContext> configurator, LifeTime lifeTime = LifeTime.Transient) where T : DbContext
//        {
//            configurator.Registrator.For<DbContext>().To<T>().DependsOnValue("connectionString", connectionString).LifeTime(lifeTime);
//            configurator.Registrator.For<IDataSource, IUnitOfWork>().To<EntityDataSource>().DependsOnComponent<EntityDataSource>("DbContext").LifeTime(lifeTime);
//        }
         
    }
}