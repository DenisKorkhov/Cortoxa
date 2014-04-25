using System;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Container.Component.Logging
{
    public static class LoggerExtentions
    {
//        public static void Logger(this IRegistration registration, Action<IComponentRegistrator<LoggerContext>> setup)
//        {
//            var configurator = new ComponentConfigurator<LoggerContext>(registration);
//            setup(configurator);
//            configurator.Build();
//        }

        public static void Logger(this IRegistration registration, Action<IComponentSetup<LoggerContext>> setupAction)
        {
            var setup = new ComponentSetup<LoggerContext>(registration);
            setupAction(setup);
            setup.Build();
        }
    }
}