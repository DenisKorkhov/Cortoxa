using System;
using Cortoxa.Configuration;
using Cortoxa.Container.Life;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Container.Services
{
    public class ServiceConfigurator : Configurator<ServiceContext>, IServiceConfiguration
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

        public IServiceConfiguration For(Type[] types)
        {
            this.Configure(x=>x.For = types);
            return this;
        }

        public IServiceConfiguration To<T>()
        {
            return To(typeof (T));
        }

        public IServiceConfiguration To(Type to)
        {
            this.Configure(x => x.To = to);
            return this;
        }

        public IRegistrationConfig Name(string name)
        {
            this.Configure(x => x.Name = name);
            return this;
        }

        public IRegistrationConfig LifeTime(LifeTime lifeTime)
        {
            this.Configure(x => x.Lifetime = lifeTime);
            return this;
        }

        public IServiceInterception Intercept { get { return interception; } }

        public IServiceConfiguration InterceptMethod(MethodInteception methodInteception)
        {
            this.Configure(x => x.Interceptors.Add(methodInteception) );
            return this;
        }

        public IServiceConfiguration ToFactory(Func<FactoryContext, object> factoryAction)
        {
            this.Configure(x => x.ToFactory = factoryAction);
            return this;
        }
    }
}