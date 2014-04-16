using System;
using Cortoxa.Configuration;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Container.Component
{
    public static class ComponentExtentions
    {
        public static IRegistration Component(this IRegistration registration, Action<IConfigurator<IRegistration>> setup)
        {
            var configurator = new Configurator<IRegistration>();
            configurator.Setup(c => c(registration));
            setup(configurator);
            return configurator.Build();
        }

        public static IRegistration Component<T>(this IRegistration registration, Action<IConfigurator<T>> setup)
        {
            var configurator = new Configurator<IRegistration>();
            configurator.Setup(c => c(registration));
//            setup(configurator);
            return configurator.Build();
        }
    }
}