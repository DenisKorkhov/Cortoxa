using System;

namespace Cortoxa.Container.Registrator
{
    public interface IResolver
    {
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