using System;

namespace Cortoxa.Container.Registrations
{
    public interface IContainerResolver
    {
        T One<T>(object arguments = null);

        object One(Type type, object arguments = null);

        T One<T>(Type type, object arguments = null);

        T One<T>(string key, object arguments = null);

        T[] All<T>(object arguments = null);

        object[] All(Type type, object arguments = null);

        T[] All<T>(Type type, object arguments = null); 
    }
}