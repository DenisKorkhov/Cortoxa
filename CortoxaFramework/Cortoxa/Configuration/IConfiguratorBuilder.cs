using System;

namespace Cortoxa.Configuration
{
    public interface IConfiguratorBuilder<T>
    {
        void ConfigureBuild(Action<T> buildStrategy);

        T Build(); 
    }
}