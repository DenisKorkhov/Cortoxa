using System;
using Cortoxa.Configuration;
using Cortoxa.Container.Life;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Container.Component
{
    public static class ComponentExtentions
    {
        public static IRegistration Component(this IRegistration registration,
            Action<IConfigurator<IRegistration>> setup)
        {
            var configurator = new Configurator<IRegistration>();
            configurator.Setup(c => c(registration));
            setup(configurator);
            return configurator.Build();
        }

        #region LifeTime

        public static IComponentConfigurator<T> LifeTime<T>(this IComponentConfigurator<T> configurator, LifeTime lifeTime) where T : class, ILifeTimeContext
        {
            configurator.Configure(x => x.LifeTime = lifeTime);
            return configurator;
        }

        public static IComponentConfigurator<T> Name<T>(this IComponentConfigurator<T> configurator, string name) where T : class, ILifeTimeContext
        {
            configurator.Configure(x => x.Name = name);
            return configurator;
        }

        public static IComponentConfigurator<T> Singleton<T>(this IComponentConfigurator<T> configurator) where T : class, ILifeTimeContext
        {
            return configurator.LifeTime(Life.LifeTime.Singleton);
        }

        public static IComponentConfigurator<T> Transient<T>(this IComponentConfigurator<T> configurator) where T : class, ILifeTimeContext
        {
            return configurator.LifeTime(Life.LifeTime.Transient);
        }

        public static IComponentConfigurator<T> PerWebRequest<T>(this IComponentConfigurator<T> configurator) where T : class, ILifeTimeContext
        {
            return configurator.LifeTime(Life.LifeTime.PerWebRequest);
        }

        public static IComponentConfigurator<T> PerThread<T>(this IComponentConfigurator<T> configurator) where T : class, ILifeTimeContext
        {
            return configurator.LifeTime(Life.LifeTime.PerThread);
        } 

        #endregion
    }
}