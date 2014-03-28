using System;
using Cortoxa.Tool;

namespace Cortoxa.Configuration
{
    public interface IConfiguration<T>
    {
        void SetBuilder(Action<T> buildAction);

        void SetStrategy(IConfigurationStrategy<T> strategy);

        void Configure(Action<T> contextAction);

        T Build();
    }
}