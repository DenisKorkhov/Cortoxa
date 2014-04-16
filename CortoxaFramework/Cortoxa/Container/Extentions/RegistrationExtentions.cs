using System;
using Cortoxa.Container.Registrator;
using Cortoxa.Container.Services;

namespace Cortoxa.Container.Extentions
{
    public static class RegistrationExtentions
    {
        public static IServiceConfigurator For(this IRegistration registration, Type typeFor)
        {
            return registration.For(new[] { typeFor });
        }

        public static IServiceConfigurator For<T>(this IRegistration registration)
        {
            return registration.For(new[] {typeof (T)});
        }

        public static IServiceConfigurator For<T, T2>(this IRegistration registration)
        {
            return registration.For(new[] { typeof(T), typeof(T2) });
        }

        public static IServiceConfigurator For<T, T2, T3>(this IRegistration registration)
        {
            return registration.For(new[] { typeof(T), typeof(T2), typeof(T3) });
        }
    }
}