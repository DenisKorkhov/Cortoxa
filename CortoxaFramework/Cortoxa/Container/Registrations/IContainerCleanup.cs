using System;

namespace Cortoxa.Container.Registrations
{
    public interface IContainerCleanup
    {
        void Release(Type type);

        void Release(object instance); 
    }
}