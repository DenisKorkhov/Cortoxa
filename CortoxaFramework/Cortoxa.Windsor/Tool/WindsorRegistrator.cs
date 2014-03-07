using System;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Cortoxa.IoC;
using Cortoxa.IoC.Common;
using Cortoxa.IoC.Factory;
using Cortoxa.IoC.Registration;
using Cortoxa.IoC.Service;
using Cortoxa.Windsor.Helpers;
using Cortoxa.Windsor.Interceptions;

namespace Cortoxa.Windsor.Tool
{
    public class WindsorRegistrator 
    {
        private readonly IWindsorContainer container;

        public WindsorRegistrator(IWindsorContainer container)
        {
            this.container = container;
        }

        public void Register(ServiceConfiguration service)
        {
            ComponentRegistration<object> component = Component.For(service.For);

            if (service.ToFactory != null)
            {
                ServiceConfiguration ctx = service;
                component = component.UsingFactoryMethod((k, cm, c) => ctx.ToFactory(new FactoryContext
                {
                    RequestedType = c.RequestedType,
                    Arguments = c.HasAdditionalArguments ? c.AdditionalArguments.Values.Cast<object>().ToArray() : null
                }), true);
            }
            else
            {
                component = component.ImplementedBy(service.To);
            }

            component = component.ToWindsorLifeTime(service.Lifetime);

            if (!string.IsNullOrEmpty(service.Name))
            {
                component = component.Named(service.Name);
            }

            if (service.Dependencies.Any())
            {
                var allDependencies = service.Dependencies.Select(dependency => Dependency.OnComponent(dependency.Key, dependency.Value)).ToArray();
                component.DependsOn(allDependencies);
            }

            if (service.Interceptors.Any())
            {
                var interceptorName = string.Format("interceptor_{0}_{1}", service.For.First().Name, Guid.NewGuid().ToString().Replace("-", string.Empty));
                //Register interceptor itself by name
                container.Register(Component.For<RegistrationInterceptor>().Named(interceptorName)
                    .DynamicParameters((k, c, p) =>
                    {
                        p["context"] = c;
                        return null;
                    })
                    .DependsOn(
                        Dependency.OnValue("interceptions", service.Interceptors),
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