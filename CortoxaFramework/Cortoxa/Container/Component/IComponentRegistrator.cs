using System;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Container.Component
{
    public interface IComponentRegistrator<T> : IComponentConfigurator<T> where T : class
    {
        void Register(Action<IRegistration, T> registrationStrategy); 
    }
}