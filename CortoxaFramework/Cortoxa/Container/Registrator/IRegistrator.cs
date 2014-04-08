using System;
using System.Reflection;
using Cortoxa.Container.Services;

namespace Cortoxa.Container.Registrator
{
    public interface IRegistrator
    {
        IRegistrator For(Type[] types, Action<IServiceConfiguration> serviceConfiguration);

        IRegistrator Type(Assembly[] assemblies, Action<IServiceConfiguration> serviceConfiguration);

        T Resolve<T>(object arguments = null);

        object Resolve(Type type, object arguments = null);

        T Resolve<T>(Type type, object arguments = null);

        T Resolve<T>(string key, object arguments = null);

        T[] ResolveAll<T>(object arguments = null);

        object[] ResolveAll(Type type, object arguments = null);

        T[] ResolveAll<T>(Type type, object arguments = null);

        void Release(Type type);

        void Release(object instance);
    }
}