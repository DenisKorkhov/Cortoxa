using System;

namespace Cortoxa.Configuration
{
    public interface IConfiguratorBuilder<T>
    {
        void SetBuilder(Action<T> builderAction);

        T Build();
    }
}