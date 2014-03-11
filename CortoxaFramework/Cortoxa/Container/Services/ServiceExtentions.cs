﻿using Cortoxa.Container.Registrator;

namespace Cortoxa.Container.Services
{
    public static class ServiceExtentions
    {
        public static IServiceConfigurator For<T>(this IRegistration registration)
        {
            return registration.For(typeof(T));
        }

        public static IServiceConfigurator For<T, T2>(this IRegistration registration)
        {
            return registration.For(typeof(T), typeof(T2));
        }

        public static IServiceConfigurator For<T, T2, T3>(this IRegistration registration)
        {
            return registration.For(typeof(T), typeof(T2), typeof(T3));
        }

        public static IServiceConfigurator For<T, T2, T3, T4>(this IRegistration registration)
        {
            return registration.For(typeof(T), typeof(T2), typeof(T3), typeof(T4));
        }
    }
}