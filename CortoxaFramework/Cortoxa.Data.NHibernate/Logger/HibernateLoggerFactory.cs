using System;
using Cortoxa.Common.Log;
using Cortoxa.Container.Registrator;
using NHibernate;

namespace Cortoxa.Data.NHibernate.Logger
{
    public class HibernateLoggerFactory : ILoggerFactory
    {
        private readonly IResolver resolver;

        public HibernateLoggerFactory(IResolver resolver)
        {
            this.resolver = resolver;
        }

        public IInternalLogger LoggerFor(string keyName)
        {
            var logger = resolver.Resolve<ILogger>( typeof(ILogger), keyName);
            return new HibernateLogger(logger);
        }

        public IInternalLogger LoggerFor(Type type)
        {
            var logger = resolver.Resolve<ILogger>(typeof(ILogger), type.Name);
            return new HibernateLogger(logger);
        }
    }

    public class HibernateLogger : IInternalLogger
    {
        private readonly ILogger logger;

        public HibernateLogger(ILogger logger)
        {
            this.logger = logger;
        }

        public void Error(object message)
        {
            logger.Error(message.ToString());
        }

        public void Error(object message, Exception exception)
        {
            logger.Error(message.ToString(), exception);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            logger.Error(string.Format(format, args));
        }

        public void Fatal(object message)
        {
            logger.Error(message.ToString());
        }

        public void Fatal(object message, Exception exception)
        {
            logger.Error(message.ToString(), exception);
        }

        public void Debug(object message)
        {
            logger.Debug(message.ToString());
        }

        public void Debug(object message, Exception exception)
        {
            logger.Debug(message + exception.Message);
        }

        public void DebugFormat(string format, params object[] args)
        {
            logger.Debug(string.Format(format, args));
        }

        public void Info(object message)
        {
            logger.Info(message.ToString());
        }

        public void Info(object message, Exception exception)
        {
            logger.Info(message.ToString(), exception);
        }

        public void InfoFormat(string format, params object[] args)
        {
            logger.Info(string.Format(format, args));
        }

        public void Warn(object message)
        {
            logger.Warn(message.ToString());
        }

        public void Warn(object message, Exception exception)
        {
            logger.Warn(message + exception.ToString());
        }

        public void WarnFormat(string format, params object[] args)
        {
            logger.Warn(string.Format(format, args));
        }

        public bool IsErrorEnabled { get { return true; } }
        public bool IsFatalEnabled { get { return true; } }
        public bool IsDebugEnabled { get { return true; } }
        public bool IsInfoEnabled { get { return true; } }
        public bool IsWarnEnabled { get { return true; } }
    }

}