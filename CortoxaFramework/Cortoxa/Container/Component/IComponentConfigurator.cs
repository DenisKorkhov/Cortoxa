using System;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Container.Component
{
    public interface IComponentConfigurator<T> where T : class
    {
        void Configure(Action<T> action);

        void Register(Action<IRegistration, T> registrationStrategy);

        IComponentConfigurator<TC> Child<TC>(TC childContext, Action<T, TC> childSetup) where TC : class, new();
    }

}