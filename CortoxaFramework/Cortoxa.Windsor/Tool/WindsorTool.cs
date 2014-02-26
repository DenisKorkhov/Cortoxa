using System;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Cortoxa.IoC.Base;
using Cortoxa.IoC.Factory;
using Cortoxa.IoC.Service;
using Cortoxa.Windsor.Helpers;
using Cortoxa.Windsor.Interceptions;

namespace Cortoxa.Windsor.Tool
{
    public class WindsorTool : IToolRegistrator, IToolResolver 
    {
        private readonly IWindsorContainer container;

        public WindsorTool(IWindsorContainer container)
        {
            this.container = container;
        }

        public void Service(ServiceContext context)
        {
            ComponentRegistration<object> component = Component.For(context.For);

            if (context.ToFactory != null)
            {
                ServiceContext ctx = context;
                component = component.UsingFactoryMethod((k, cm, c) => ctx.ToFactory(new FactoryContext
                {
                    RequestedType = c.RequestedType,
                    Arguments = c.HasAdditionalArguments ? c.AdditionalArguments.Values.Cast<object>().ToArray() : null
                }), true);
            }
            else
            {
                component = component.ImplementedBy(context.To);
            }

            component = component.ToWindsorLifeTime(context.Lifetime);

            if (!string.IsNullOrEmpty(context.Name))
            {
                component = component.Named(context.Name);
            }

            if (context.Dependencies.Any())
            {
                var allDependencies = context.Dependencies.Select(dependency => Dependency.OnComponent(dependency.Key, dependency.Value)).ToArray();
                component.DependsOn(allDependencies);
            }

            if (context.Interceptors.Any())
            {
                var interceptorName = string.Format("interceptor_{0}_{1}", context.For.First().Name, Guid.NewGuid().ToString().Replace("-", string.Empty));
                //Register interceptor itself by name
                container.Register(Component.For<RegistrationInterceptor>().Named(interceptorName)
                    .DynamicParameters((k, c, p) =>
                    {
                        p["context"] = c;
                        return null;
                    })
                    .DependsOn(
                        Dependency.OnValue("interceptions", context.Interceptors),
                        Dependency.OnValue("container", container),
                        Dependency.OnValue("context", null)
                    ).LifestyleTransient()
                    );
                component.Interceptors(interceptorName);
            }
            container.Register(component);
        }

        public void Service(Action<IServiceBuilderFor> serviceAction)
        {
            
        }

        public T One<T>(object arguments = null)
        {
            return arguments != null ? container.Resolve<T>(arguments) : container.Resolve<T>();
        }

        public object One(Type type, object arguments = null)
        {
            return arguments != null ? container.Resolve(type, arguments) : container.Resolve(type);
        }

        public T One<T>(Type type, object arguments = null)
        {
            var result = arguments != null ? (T)container.Resolve(type, arguments) : container.Resolve(type);
            return (T)result;
        }

        public T One<T>(string key, object arguments = null)
        {
            return arguments != null ? container.Resolve<T>(key, arguments) : container.Resolve<T>(key);
        }

        public T[] All<T>(object arguments = null)
        {
            return arguments != null ? container.ResolveAll<T>(arguments) : container.ResolveAll<T>();
        }

        public object[] All(Type type, object arguments = null)
        {
            var result = arguments != null ? container.ResolveAll(type, arguments) : container.ResolveAll(type);
            return result.Cast<object>().ToArray();
        }

        public T[] All<T>(Type type, object arguments = null)
        {
            var result = arguments != null ? container.ResolveAll(type, arguments) : container.ResolveAll(type);
            return result.Cast<T>().ToArray();
        }

        public void Release(Type type)
        {
            var instance = One(type);
            if (instance != null)
            {
                container.Release(instance);
            }
        }

        public void Release(object instance)
        {
            container.Release(instance);
        }
    }
}