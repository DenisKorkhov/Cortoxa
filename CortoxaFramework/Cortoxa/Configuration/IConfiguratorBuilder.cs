using System;

namespace Cortoxa.Configuration
{
    public interface IConfiguratorBuilder<T>
    {
        void OnBuild(Action<T> buildStrategy);

        T Build(); 
    }
}