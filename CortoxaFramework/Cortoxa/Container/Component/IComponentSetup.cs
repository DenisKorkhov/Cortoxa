using System;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Container.Component
{
    public interface IComponentSetup<T>
    {
        IComponentConfigurator<K> Setup<K>(Func<K> setupnContext, Action<IRegistration, K> setupAction) where K : class, new();
    }
}