using System;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Cortoxa.Configuration;
using Cortoxa.Container.Services;
using Cortoxa.Windsor.Helpers;
using Cortoxa.Windsor.Interceptions;
using Cortoxa.Windsor.Tool;

namespace Cortoxa.Windsor.Registrators
{
    public class WindsorServiceRegistration : IConfigurationStrategy<ServiceContext>
    {
        private readonly IWindsorContainer container;
        
        public WindsorServiceRegistration(IWindsorContainer container)
        {
            this.container = container;
        }

        public void Execute(ServiceContext context)
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
            } else if (context.ToFactoryResolver != null)
            {
                ServiceContext ctx = context;
                component = component.UsingFactoryMethod((k, cm, c) => ctx.ToFactoryResolver(new FactoryContext
                {
                    RequestedType = c.RequestedType,
                    Arguments = c.HasAdditionalArguments ? c.AdditionalArguments.Values.Cast<object>().ToArray() : null
                }, new WindsorResolver(k)), true);
            }
            else
            {
                component = component.ImplementedBy(context.To);
            }

            if (context.ComponentDependencies.Any())
            {
                component = context.ComponentDependencies.Aggregate(component, (current, componentDependency) => current.DependsOn(Dependency.OnComponent(componentDependency.Key, componentDependency.Value)));
            }

            if (context.ValueDependencies.Any())
            {
                component = context.ValueDependencies.Aggregate(component, (current, dependency) => current.DependsOn(Property.ForKey(dependency.Key).Eq(dependency.Value)));
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

            if (!string.IsNullOrEmpty(context.Name))
            {
                component = component.Named(context.Name);
            }

            component = component.ToWindsorLifeTime(context.Lifetime);

            container.Register(component);
        }
    }
}