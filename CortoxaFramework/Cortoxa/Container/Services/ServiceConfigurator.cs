using System;
using System.Collections.Generic;
using Cortoxa.Configuration;
using Cortoxa.Container.Life;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Container.Services
{
    public class ServiceConfigurator : Configurator<ServiceContext>, IServiceConfigurator
    {
        private readonly IServiceInterception interception;

        public ServiceConfigurator()
        {
            this.interception = new ServiceInterception(this);
        }

        public override ServiceContext Build()
        {
            var result = base.Build();
            return result;
        }

        public IServiceConfigurator For(Type[] types)
        {
            this.Configure(x=>x.For = types);
            return this;
        }

        public IServiceConfigurator To<T>()
        {
            return To(typeof (T));
        }

        public IServiceConfigurator To(Type to)
        {
            this.Configure(x => x.To = to);
            return this;
        }

        public IRegistrationConfigurator Name(string name)
        {
            this.Configure(x => x.Name = name);
            return this;
        }

        public IRegistrationConfigurator LifeTime(LifeTime lifeTime)
        {
            this.Configure(x => x.Lifetime = lifeTime);
            return this;
        }

        public IServiceInterception Intercept { get { return interception; } }

        public IServiceConfigurator InterceptMethod(MethodInteception methodInteception)
        {
            this.Configure(x => x.Interceptors.Add(methodInteception) );
            return this;
        }

        public IServiceConfigurator ToFactory(Func<FactoryContext, object> factoryAction)
        {
            this.Configure(x => x.ToFactory = factoryAction);
            return this;
        }

        public IServiceConfigurator ToFactory(Func<FactoryContext, IResolver, object> factoryAction)
        {
            this.Configure(x => x.ToFactoryResolver = factoryAction);
            return this;
        }

        public IServiceConfigurator DependsOnComponent(Type type, string componentName)
        {
            this.Configure(x => x.ComponentDependencies.Add(new KeyValuePair<Type, string>(type, componentName)));
            return this;
        }

        public IServiceConfigurator DependsOnComponent<T>(string componentName)
        {
            return DependsOnComponent(typeof(T), componentName);
        }

        public IServiceConfigurator DependsOnValue(string name, object value)
        {
            this.Configure(x => x.ValueDependencies.Add(new KeyValuePair<string, object>(name, value)));
            return this;
        }
    }
}