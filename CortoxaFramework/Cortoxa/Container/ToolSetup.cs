using System;
using Cortoxa.Container.Common;

namespace Cortoxa.Container
{
    public class ToolSetup<T> : ISetupBuilder<T>, ISetupConfigurator<T> 
    {
        protected T Value;

        public void Create(Func<T> action)
        {
            Value = action();
        }

        public void Configure(Action<T> action)
        {
            action(Value);
        }

        public T Build()
        {
            return Value;
        }
    }
}