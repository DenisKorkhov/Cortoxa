using System;
using Cortoxa.Configuration;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Container.Component.Logging
{
    public static class LoggerExtentions
    {
        public static IRegistration Logger(this IRegistration registration, Action<IComponentRegistrator<LoggerContext>> setup)
        {
            var configurator = new ComponentConfigurator<LoggerContext>(registration);
            setup(configurator);
            configurator.Build();
            return registration;
        } 
    }
}