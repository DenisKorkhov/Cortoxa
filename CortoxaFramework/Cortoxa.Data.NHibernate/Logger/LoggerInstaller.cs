using Cortoxa.Container;
using NHibernate;

namespace Cortoxa.Data.NHibernate.Logger
{
    public static class LoggerInstaller
    {
        public static IToolContainer InstallHibernateLogger(this IToolContainer container)
        {
            LoggerProvider.SetLoggersFactory(new HibernateLoggerFactory(container.Resolver));
            return container;
        }
    }
}