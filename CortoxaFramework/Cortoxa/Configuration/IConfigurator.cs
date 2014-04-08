using System;

namespace Cortoxa.Configuration
{
    public interface IConfigurator<T>
    {
        void Configure(Action<T> contextAction);
    }
}