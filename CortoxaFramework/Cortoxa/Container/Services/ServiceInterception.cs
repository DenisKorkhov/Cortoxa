using System;
using System.Linq.Expressions;
using Cortoxa.Reflection;

namespace Cortoxa.Container.Services
{
    public class ServiceInterception : IServiceInterception
    {
        private readonly IServiceConfiguration configuration;

        public ServiceInterception(IServiceConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IServiceConfiguration Method<T>(Expression<Action<T>> methodExpr, Func<InterceptionContext, object> action)
        {
            return configuration.InterceptMethod(new MethodInteception(action, MethodInteceptionType.Process,
                    methodExpr.MethodFromExpression()));
        }

        public IServiceConfiguration Method<T>(Expression<Action<T>> methodExpr, Action<InterceptionContext> action)
        {
            return
                configuration.InterceptMethod(new MethodInteception(action, MethodInteceptionType.Process,
                    methodExpr.MethodFromExpression()));
        }

        public IServiceConfiguration Method(Func<InterceptionContext, object> action)
        {
            return configuration.InterceptMethod(new MethodInteception(action, MethodInteceptionType.Process));
        }

        public IServiceConfiguration Method(Action<InterceptionContext> action)
        {
            return configuration.InterceptMethod(new MethodInteception(action, MethodInteceptionType.Process));
        }

        public IServiceConfiguration Before<T>(Expression<Action<T>> methodExpr, Func<InterceptionContext, object> action)
        {
            return
                configuration.InterceptMethod(new MethodInteception(action, MethodInteceptionType.Before,
                    methodExpr.MethodFromExpression()));
        }

        public IServiceConfiguration Before<T>(Expression<Action<T>> methodExpr, Action<InterceptionContext> action)
        {
            return
                configuration.InterceptMethod(new MethodInteception(action, MethodInteceptionType.Before,
                    methodExpr.MethodFromExpression()));
        }

        public IServiceConfiguration Before(Func<InterceptionContext, object> action)
        {
            return configuration.InterceptMethod(new MethodInteception(action, MethodInteceptionType.Before));
        }

        public IServiceConfiguration Before(Action<InterceptionContext> action)
        {
            return configuration.InterceptMethod(new MethodInteception(action, MethodInteceptionType.Before));
        }

        public IServiceConfiguration After<T>(Expression<Action<T>> methodExpr, Func<InterceptionContext, object> action)
        {
            return
                configuration.InterceptMethod(new MethodInteception(action, MethodInteceptionType.After,
                    methodExpr.MethodFromExpression()));
        }

        public IServiceConfiguration After<T>(Expression<Action<T>> methodExpr, Action<InterceptionContext> action)
        {
            return
                configuration.InterceptMethod(new MethodInteception(action, MethodInteceptionType.After,
                    methodExpr.MethodFromExpression()));
        }

        public IServiceConfiguration After(Func<InterceptionContext, object> action)
        {
            return configuration.InterceptMethod(new MethodInteception(action, MethodInteceptionType.After));
        }

        public IServiceConfiguration After(Action<InterceptionContext> action)
        {
            return configuration.InterceptMethod(new MethodInteception(action, MethodInteceptionType.After));
        }
    }
}