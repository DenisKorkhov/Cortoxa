using System;

namespace Cortoxa.IoC.Common
{
    public interface ISetupConfigurator<T>
    {
        void Create(Func<T> action);

        void Configure(Action<T> action); 
    }
}