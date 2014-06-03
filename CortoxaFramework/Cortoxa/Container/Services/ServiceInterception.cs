using System;
using System.Linq.Expressions;
using System.Reflection;
using Cortoxa.Reflection;

namespace Cortoxa.Container.Services
{
    public class ServiceInterception : IServiceInterception
    {
        private readonly IServiceConfigurator configuration;

        public ServiceInterception(IServiceConfigurator configuration)
        {
            this.configuration = configuration;
        }

        public IServiceConfigurator Method<T>(Expression<Action<T>> methodExpr, Func<InterceptionContext, object> action)
        {
            return configuration.InterceptMethod(new MethodInteception(action, MethodInteceptionType.Process,
                    methodExpr.MethodFromExpression()));
        }

        public IServiceConfigurator Method<T>(Expression<Action<T>> methodExpr, Action<InterceptionContext> action)
        {
            return
                configuration.InterceptMethod(new MethodInteception(action, MethodInteceptionType.Process,
                    methodExpr.MethodFromExpression()));
        }

        public IServiceConfigurator Method(Func<InterceptionContext, object> action)
        {
            return configuration.InterceptMethod(new MethodInteception(action, MethodInteceptionType.Process));
        }

        public IServiceConfigurator Method(Action<InterceptionContext> action)
        {
            return configuration.InterceptMethod(new MethodInteception(action, MethodInteceptionType.Process));
        }

        public IServiceConfigurator Before<T>(Expression<Action<T>> methodExpr, Func<InterceptionContext, object> action)
        {
            return
                configuration.InterceptMethod(new MethodInteception(action, MethodInteceptionType.Before,
                    methodExpr.MethodFromExpression()));
        }

        public IServiceConfigurator Before<T>(Expression<Action<T>> methodExpr, Action<InterceptionContext> action)
        {
            return
                configuration.InterceptMethod(new MethodInteception(action, MethodInteceptionType.Before,
                    methodExpr.MethodFromExpression()));
        }

        public IServiceConfigurator Before(Func<InterceptionContext, object> action)
        {
            return configuration.InterceptMethod(new MethodInteception(action, MethodInteceptionType.Before));
        }

        public IServiceConfigurator Before(Action<InterceptionContext> action)
        {
            return configuration.InterceptMethod(new MethodInteception(action, MethodInteceptionType.Before));
        }

        public IServiceConfigurator After<T>(Expression<Action<T>> methodExpr, Func<InterceptionContext, object> action)
        {
            return configuration.InterceptMethod(new MethodInteception(action, MethodInteceptionType.After, methodExpr.MethodFromExpression()));
        }

        public IServiceConfigurator After<T>(Expression<Action<T>> methodExpr, Action<InterceptionContext> action)
        {
            return configuration.InterceptMethod(new MethodInteception(action, MethodInteceptionType.After,methodExpr.MethodFromExpression()));
        }

        public IServiceConfigurator After<T>(string methodName, Action<InterceptionContext> action)
        {
            var methodInfo = typeof(T).GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            return configuration.InterceptMethod(new MethodInteception(action, MethodInteceptionType.After, methodInfo));
        }

        public IServiceConfigurator After(Func<InterceptionContext, object> action)
        {
            return configuration.InterceptMethod(new MethodInteception(action, MethodInteceptionType.After));
        }

        public IServiceConfigurator After(Action<InterceptionContext> action)
        {
            return configuration.InterceptMethod(new MethodInteception(action, MethodInteceptionType.After));
        }

        public IServiceConfigurator ByName(Action<InterceptionContext> action, string interceptorName)
        {
            return configuration.InterceptWith(interceptorName);

        }
    }
}