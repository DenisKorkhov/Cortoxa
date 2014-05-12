using System;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Configuration
{
    public interface IRegistrationConfigurator<T>
    {
        void Configure(Action<T> action);

        T Build();
    }
}