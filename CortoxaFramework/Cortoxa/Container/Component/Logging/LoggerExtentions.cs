
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

        public static IComponentConfigurator<LoggerContext> Logger<T>(this IRegistration registration)
        {
            var configurator = new ComponentConfigurator<LoggerContext>(registration);
            return configurator;
        }
    }
}