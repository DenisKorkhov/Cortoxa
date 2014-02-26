using System;
using Cortoxa.IoC.Base;

namespace Cortoxa.IoC.Service
{
    public static class ServiceExtentions
    {
        #region Service

        public static IToolRegistrator Service<T>(this IToolRegistrator registrator, Action<IServiceBuilder> serviceAction)
        {
            return registrator.Service(serviceAction, typeof(T));
        }

        public static IToolRegistrator Service<T, T2>(this IToolRegistrator registrator, Action<IServiceBuilder> serviceAction)
        {
            return registrator.Service(serviceAction, typeof(T), typeof(T2));
        }

        public static IToolRegistrator Service<T, T2, T3>(this IToolRegistrator registrator, Action<IServiceBuilder> serviceAction)
        {
            return registrator.Service(serviceAction, typeof(T), typeof(T2), typeof(T3));
        }

        public static IToolRegistrator Service<T, T2, T3, T4>(this IToolRegistrator registrator, Action<IServiceBuilder> serviceAction)
        {
            return registrator.Service(serviceAction, typeof(T), typeof(T2), typeof(T3), typeof(T4));
        }

        public static IToolRegistrator Service(this IToolRegistrator registrator,
            Action<IServiceBuilder> serviceAction, params Type[] typeFor)
        {
            ServiceBuilder service = ServiceBuilder.For(typeFor);
            serviceAction(service);
            return registrator.Service(service.Context);
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

