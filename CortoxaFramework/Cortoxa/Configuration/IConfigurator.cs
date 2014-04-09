using System;

namespace Cortoxa.Configuration
{
    public interface IConfigurator<T>
    {
        void Setup(Action<Action<T>> contextAction);

        void Configure(Action<T> action);

        T Build();
    }
}