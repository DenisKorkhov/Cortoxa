using System;
using Cortoxa.Configuration;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Container.Components
{
    public static class ComponentExtentions
    {
//        public static IRegistrator Component(this IRegistrator registrator, Action<Action<Action<IRegistrator>>> setup)
//        {
//            setup(c => c(registrator));
//            return registrator;
//        }

        public static IRegistrator Component(this IRegistrator registrator, Action<IConfigurator<IRegistrator>> setup)
        {
            var configurator = new Configurator<IRegistrator>();
            configurator.Setup(c => c(registrator));
            setup(configurator);
            return configurator.Build();
        }
    }
}