using Cortoxa.IoC.Common;
using Cortoxa.IoC.Registration;

namespace Cortoxa.IoC.Extentions
{
    public static class RegistrationExtentions
    {
        public static IServiceBuilder For<T>(this IRegistration registration)
        {
            return registration.For(typeof(T));
        }

        public static IServiceBuilder For<T, T2>(this IRegistration registration)
        {
            return registration.For(typeof(T), typeof(T2));
        }

        public static IServiceBuilder For<T, T2, T3>(this IRegistration registration)
        {
            return registration.For(typeof(T), typeof(T2), typeof(T3));
        }

        public static IServiceBuilder For<T, T2, T3, T4>(this IRegistration registration)
        {
            return registration.For(typeof(T), typeof(T2), typeof(T3), typeof(T4));
        }
    }
}