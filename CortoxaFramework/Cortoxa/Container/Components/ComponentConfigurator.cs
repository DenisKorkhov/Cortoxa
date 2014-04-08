using System;
using Cortoxa.Configuration;
using Cortoxa.Container.Registrator;


namespace Cortoxa.Container.Components
{
    public class ComponentConfigurator<T> : IConfigurator<T>, IComponent
    {
        private readonly IRegistrator registrator;

        public ComponentConfigurator(IRegistrator registrator)
        {
            this.registrator = registrator;
        }

        
        public T Context { get; private set; }
        public void Configure(Action<T> contextAction)
        {
            throw new NotImplementedException();
        }
    }
}