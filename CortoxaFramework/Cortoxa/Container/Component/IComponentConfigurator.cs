using System;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Container.Component
{
    public interface IComponentConfigurator<T> where T : class
    {
        void Configure(Action<T> action);
    }
}