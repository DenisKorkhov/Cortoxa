using System;
using System.Linq.Expressions;
using Cortoxa.IoC.Base;
using Cortoxa.IoC.Interception;
using Cortoxa.Reflection;

namespace Cortoxa.IoC.Service
{
    public class ServiceInterception : IServiceInterception
    {
        private readonly IServiceBuilder serviceBuilder;

        public ServiceInterception(IServiceBuilder serviceBuilder)
        {
            this.serviceBuilder = serviceBuilder;
        }

        public IServiceBuilder Method<T>(Expression<Action<T>> methodExpr, Func<InterceptionContext, object> action)
        {
            return
                serviceBuilder.InterceptMethod(new MethodInteception(action, MethodInteceptionType.Process,
                    methodExpr.MethodFromExpression()));
        }

        public IServiceBuilder Method<T>(Expression<Action<T>> methodExpr, Action<InterceptionContext> action)
        {
            return
                serviceBuilder.InterceptMethod(new MethodInteception(action, MethodInteceptionType.Process,
                    methodExpr.MethodFromExpression()));
        }

        public IServiceBuilder Method(Func<InterceptionContext, object> action)
        {
            return serviceBuilder.InterceptMethod(new MethodInteception(action, MethodInteceptionType.Process));
        }

        public IServiceBuilder Method(Action<InterceptionContext> action)
        {
            return serviceBuilder.InterceptMethod(new MethodInteception(action, MethodInteceptionType.Process));
        }

        public IServiceBuilder Before<T>(Expression<Action<T>> methodExpr, Func<InterceptionContext, object> action)
        {
            return
                serviceBuilder.InterceptMethod(new MethodInteception(action, MethodInteceptionType.Before,
                    methodExpr.MethodFromExpression()));
        }

        public IServiceBuilder Before<T>(Expression<Action<T>> methodExpr, Action<InterceptionContext> action)
        {
            return
                serviceBuilder.InterceptMethod(new MethodInteception(action, MethodInteceptionType.Before,
                    methodExpr.MethodFromExpression()));
        }

        public IServiceBuilder Before(Func<InterceptionContext, object> action)
        {
            return serviceBuilder.InterceptMethod(new MethodInteception(action, MethodInteceptionType.Before));
        }

        public IServiceBuilder Before(Action<InterceptionContext> action)
        {
            return serviceBuilder.InterceptMethod(new MethodInteception(action, MethodInteceptionType.Before));
        }

        public IServiceBuilder After<T>(Expression<Action<T>> methodExpr, Func<InterceptionContext, object> action)
        {
            return
                serviceBuilder.InterceptMethod(new MethodInteception(action, MethodInteceptionType.After,
                    methodExpr.MethodFromExpression()));
        }

        public IServiceBuilder After<T>(Expression<Action<T>> methodExpr, Action<InterceptionContext> action)
        {
            return
                serviceBuilder.InterceptMethod(new MethodInteception(action, MethodInteceptionType.After,
                    methodExpr.MethodFromExpression()));
        }

        public IServiceBuilder After(Func<InterceptionContext, object> action)
        {
            return serviceBuilder.InterceptMethod(new MethodInteception(action, MethodInteceptionType.After));
        }

        public IServiceBuilder After(Action<InterceptionContext> action)
        {
            return serviceBuilder.InterceptMethod(new MethodInteception(action, MethodInteceptionType.After));
        }
    }
}