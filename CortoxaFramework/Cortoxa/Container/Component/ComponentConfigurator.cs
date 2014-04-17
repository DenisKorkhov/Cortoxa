using System;
using Cortoxa.Configuration;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Container.Component
{
    public class ComponentConfigurator<T> : Configurator<T>, IComponentConfigurator<T> where T : class, new()
    {
        private readonly IRegistration container;

        public ComponentConfigurator(IRegistration container)
        {
            this.container = container;
            this.Setup(s => s(new T()));
        }

        public IRegistration Registrator
        {
            get { return container; }
        }
    }
}