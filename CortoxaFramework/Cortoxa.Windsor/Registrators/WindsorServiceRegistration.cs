using System;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Cortoxa.Configuration;
using Cortoxa.Container.Services;
using Cortoxa.Windsor.Helpers;
using Cortoxa.Windsor.Interceptions;

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
    }
}