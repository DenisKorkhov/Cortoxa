using System;
using System.Reflection;
using Cortoxa.Container.Registrator;
using Cortoxa.Container.Services;
using Cortoxa.Container.Types;

namespace Cortoxa.Container.Extentions
{
    public static class RegistrationExtentions
    {

        #region Service Registration
        public static IServiceConfigurator For(this IRegistration registration, Type typeFor)
        {
            return registration.For(new[] { typeFor });
        }

        public static IServiceConfigurator For<T>(this IRegistration registration)
        {
            return registration.For(new[] { typeof(T) });
        }

        public static IServiceConfigurator For<T, T2>(this IRegistration registration)
        {
            return registration.For(new[] { typeof(T), typeof(T2) });
        }

        public static IServiceConfigurator For<T, T2, T3>(this IRegistration registration)
        {
            return registration.For(new[] { typeof(T), typeof(T2), typeof(T3) });
        } 
        #endregion

        #region Type Registration

        public static ITypeConfigurator Type(this IRegistration registration)
        {
            return registration.Type(new Assembly[0]);
        }

        public static ITypeConfigurator Type(this IRegistration registration, Assembly[] assemblies)
        {
            var result = registration.Type();
            return result.Assemblies(assemblies);
        }

        public static ITypeConfigurator FromCallingAssembly(this IAssemblyTypeConfigurator configurator)
        {
            return configurator.Assemblies(new[] {Assembly.GetCallingAssembly()});
        }

        public static ITypeConfigurator FromExecutingAssembly(this IAssemblyTypeConfigurator configurator)
        {
            return configurator.Assemblies(new[] { Assembly.GetExecutingAssembly() });
        }

        public static ITypeConfigurator FromAssemblyWithType<T>(this IAssemblyTypeConfigurator configurator)
        {
            return configurator.FromAssemblyWithType(typeof(T));
        }

        public static ITypeConfigurator FromAssemblyWithType(this IAssemblyTypeConfigurator configurator, Type type)
        {
            return configurator.Assemblies(new[] { type.Assembly });
        }

        #endregion
    }
}