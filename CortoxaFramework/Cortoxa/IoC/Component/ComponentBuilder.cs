using System;

namespace Cortoxa.IoC.Component
{
    public class ComponentBuilder : IComponentBuilder
    {
        public void Create(Func<ComponentConfiguration> action)
        {
            throw new NotImplementedException();
        }

        public void Configure(Action<ComponentConfiguration> action)
        {
            throw new NotImplementedException();
        }
    }
}