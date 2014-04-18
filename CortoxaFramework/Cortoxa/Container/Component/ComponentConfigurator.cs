using System;
using Cortoxa.Configuration;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Container.Component
{
    public class ComponentConfigurator<T> : Configurator<T>, IComponentRegistrator<T> where T : class, new()
    {
        private readonly IRegistration container;

        public ComponentConfigurator(IRegistration container)
        {
            this.container = container;
            this.Setup(s => s(new T()));
        }

        public void Register(Action<IRegistration, T> registrationStrategy)
        {
            this.ConfigureBuild(c=> registrationStrategy(container, c));
        }
    }
}