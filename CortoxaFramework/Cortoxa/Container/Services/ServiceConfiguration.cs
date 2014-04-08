using System;
using Cortoxa.Configuration;
using Cortoxa.Container.Life;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Container.Services
{
    public class ServiceConfiguration : ConfigurationBase<ServiceContext>, IServiceConfiguration
    {
        private readonly IServiceInterception interception;

        public ServiceConfiguration() : base(new ServiceContext())
        {
            this.interception = new ServiceInterception(this);
        }

        public IServiceConfiguration For(Type[] types)
        {
            context.For = types;
            return this;
        }

        public IServiceConfiguration To<T>()
        {
            return To(typeof (T));
        }

        public IServiceConfiguration To(Type to)
        {
            context.To = to;
            return this;
        }

        public IRegistrationConfig Name(string name)
        {
            context.Name = name;
            return this;
        }

        public IRegistrationConfig LifeTime(LifeTime lifeTime)
        {
            context.Lifetime = lifeTime;
            return this;
        }

        public IServiceInterception Intercept { get { return interception; } }

        public IServiceConfiguration InterceptMethod(MethodInteception methodInteception)
        {
            context.Interceptors.Add(methodInteception);
            return this;
        }

        public IServiceConfiguration ToFactory(Func<FactoryContext, object> action)
        {
            context.ToFactory = action;
            return this;
        }
    }
}