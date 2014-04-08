using System;
using Cortoxa.Container.Registrator;
using Cortoxa.Container.Services;

namespace Cortoxa.Container.Extentions
{
    public static class RegistrationExtentions
    {
        public static IRegistrator For(this IRegistrator registrator, Type typeFor, Action<IServiceConfiguration> serviceConfiguration)
        {
            return registrator.For(new[] { typeFor }, serviceConfiguration);
        }

        public static IRegistrator For<T>(this IRegistrator registrator, Action<IServiceConfiguration> serviceConfiguration)
        {
            return registrator.For(new[] {typeof (T)}, serviceConfiguration);
        }

        public static IRegistrator For<T, T2>(this IRegistrator registrator, Action<IServiceConfiguration> serviceConfiguration)
        {
            return registrator.For(new[] { typeof(T), typeof(T2) }, serviceConfiguration);
        }

        public static IRegistrator For<T, T2, T3>(this IRegistrator registrator, Action<IServiceConfiguration> serviceConfiguration)
        {
            return registrator.For(new[] { typeof(T), typeof(T2), typeof(T3) }, serviceConfiguration);
        }
    }
}