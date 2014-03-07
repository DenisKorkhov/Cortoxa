using System;
using Cortoxa.Components;
using Cortoxa.IoC.Base;
using Cortoxa.IoC.Base.ServiceFamily;

namespace Cortoxa.IoC.Service
{
    public static class ServiceExtentions
    {
        #region Register

//        public static IToolContainer Register(this IToolContainer registrator, Action<IServiceBuilderFor> serviceAction)
//        {
//            var context = new ServiceConfiguration();
//
//            var builder = new ServiceBuilder();
//            serviceAction(builder);
//            builder.Register(registrator);
//            return registrator;
//        }

        public static IToolContainer Component(this IToolContainer registrator, Action<IComponentSetup> componentAction)
        {
            return registrator;
        }

        #endregion

        #region Lifetime

        public static IServiceBuilder Transient(this IServiceBuilder service)
        {
            return service.LifeTime(LifeTime.Transient);
        }

        public static IServiceBuilder PerWebRequest(this IServiceBuilder service)
        {
            return service.LifeTime(LifeTime.PerWebRequest);
        }

        public static IServiceBuilder PerThread(this IServiceBuilder service)
        {
            return service.LifeTime(LifeTime.PerThread);
        }

        public static IServiceBuilder Singleton(this IServiceBuilder service)
        {
            return service.LifeTime(LifeTime.Singleton);
        }

        #endregion
    }
}

