using System;
using Cortoxa.Common.Log;
using Cortoxa.Container.Components;
using Cortoxa.Container.Services;
using log4net;

namespace Cortoxa.Log4Net
{
    public static class Log4NetSetup
    {
        public static IComponentConfigurator<LoggerComponent> Nlog(this IComponentRegistrator componentRegistrator)
        {
            return componentRegistrator.Configure<LoggerComponent>(c => c.Logger, r => r.For<ILogger>()
                .Intercept.Method<ILogger>(m => m.Info(default(string)), context => GetLogger(context.ResolverType.FullName).Info(context.Arguments[0] as string))
                .Intercept.Method<ILogger>(m => m.Trace(default(string)), context => GetLogger(context.ResolverType.FullName).Info(context.Arguments[0] as string))
                .Intercept.Method<ILogger>(m => m.Warn(default(string)), context => GetLogger(context.ResolverType.FullName).Info(context.Arguments[0] as string))
                .Intercept.Method<ILogger>(m => m.Debug(default(string)), context => GetLogger(context.ResolverType.FullName).Info(context.Arguments[0] as string))
                .Intercept.Method<ILogger>(m => m.Error(default(string)), context => GetLogger(context.ResolverType.FullName).Info(context.Arguments[0] as string))
                .Intercept.Method<ILogger>(m => m.Info(default(string), default(string[])), context => GetLogger(context.ResolverType.FullName).Info(context.Arguments[0] as string))
                .Intercept.Method<ILogger>(m => m.Trace(default(string), default(string[])), context => GetLogger(context.ResolverType.FullName).Debug(context.Arguments[0] as string))
                .Intercept.Method<ILogger>(m => m.Warn(default(string), default(string[])), context => GetLogger(context.ResolverType.FullName).Warn(context.Arguments[0] as string))
                .Intercept.Method<ILogger>(m => m.Debug(default(string), default(string[])), context => GetLogger(context.ResolverType.FullName).Debug(context.Arguments[0] as string))
                .Intercept.Method<ILogger>(m => m.Error(default(string), default(string[])), context => GetLogger(context.ResolverType.FullName).Error(context.Arguments[0] as string))
                .Intercept.Method<ILogger>(m => m.Error(default(string), default(Exception)), context => GetLogger(context.ResolverType.FullName).Error(context.Arguments[0] as string, context.Arguments[1] as Exception)));
        }
        private static ILog GetLogger(string name)
        {
            return LogManager.GetLogger(name);
        }
    }
}