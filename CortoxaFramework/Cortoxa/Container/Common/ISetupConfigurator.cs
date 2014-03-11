using System;

namespace Cortoxa.Container.Common
{
    public interface ISetupConfigurator<T>
    {
        void Create(Func<T> action);

        void Configure(Action<T> action); 
    }
}