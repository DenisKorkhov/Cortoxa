using System;
using Cortoxa.Common;
using Cortoxa.Container.Components;
using Cortoxa.Container.Registrator;
using Cortoxa.Container.Services;
using NLog;

namespace Cortoxa.NLog
{
    public class LoggerConfigurator : ComponentConfigurator<LoggerComponent>
    {
        private readonly IRegistration registrator;

        public LoggerConfigurator(IRegistration registrator) : base(new LoggerComponent())
        {
            this.registrator = registrator;
        }

        public override void Init()
        {
            Context.Logger = 
                registrator.For<ILogger>()
                .Intercept.Method<ILogger>(m => m.Info(default(string)), context => GetLogger(context.ResolverType.FullName).Info(context.Arguments[0] as string))
                .Intercept.Method<ILogger>(m => m.Trace(default(string)), context => GetLogger(context.ResolverType.FullName).Info(context.Arguments[0] as string))
                .Intercept.Method<ILogger>(m => m.Warn(default(string)), context => GetLogger(context.ResolverType.FullName).Info(context.Arguments[0] as string))
                .Intercept.Method<ILogger>(m => m.Debug(default(string)), context => GetLogger(context.ResolverType.FullName).Info(context.Arguments[0] as string))
                .Intercept.Method<ILogger>(m => m.Error(default(string)), context => GetLogger(context.ResolverType.FullName).Info(context.Arguments[0] as string))
                .Intercept.Method<ILogger>(m => m.Info(default(string), default(string[])), context => GetLogger(context.ResolverType.FullName).Info(context.Arguments[0] as string, context.Arguments[1] as object[]))
                .Intercept.Method<ILogger>(m => m.Trace(default(string), default(string[])), context => GetLogger(context.ResolverType.FullName).Trace(context.Arguments[0] as string, context.Arguments[1] as object[]))
                .Intercept.Method<ILogger>(m => m.Warn(default(string), default(string[])), context => GetLogger(context.ResolverType.FullName).Warn(context.Arguments[0] as string, context.Arguments[1] as object[]))
                .Intercept.Method<ILogger>(m => m.Debug(default(string), default(string[])), context => GetLogger(context.ResolverType.FullName).Debug(context.Arguments[0] as string, context.Arguments[1] as object[]))
                .Intercept.Method<ILogger>(m => m.Error(default(string), default(string[])), context => GetLogger(context.ResolverType.FullName).Error(context.Arguments[0] as string, context.Arguments[1] as object[]))
                .Intercept.Method<ILogger>(m => m.Error(default(string), default(Exception)), context => GetLogger(context.ResolverType.FullName).ErrorException(context.Arguments[0] as string, context.Arguments[1] as Exception));
        }

        private Logger GetLogger(string name)
        {
            return LogManager.GetLogger(name);
        }
    }
}