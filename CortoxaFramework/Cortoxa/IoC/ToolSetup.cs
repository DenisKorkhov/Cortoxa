using System;
using Cortoxa.IoC.Base;
using Cortoxa.IoC.Common;

namespace Cortoxa.IoC
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