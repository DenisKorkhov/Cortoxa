using System;
using Cortoxa.Common.Configuration;
using Cortoxa.Container.Common;

namespace Cortoxa.Container.Services
{
    internal class ServiceConfigurator : BaseConfigurator<ServiceContext>, IServiceConfigurator
    {
        private ServiceInterception interception;

        internal ServiceConfigurator(IConfigurationStrategy<ServiceContext> strategy) : base(strategy, new ServiceContext())
        {
            this.interception = new ServiceInterception(this);
        }

        public IServiceConfigurator For(Type[] types)
        {
            Context.For = types;
            return this;
        }

        public IServiceConfigurator To<T>()
        {
            return To(typeof (T));
        }

        public IServiceConfigurator To(Type to)
        {
            Context.To = to;
            return this;
        }

        public IServiceConfigurator Name(string name)
        {
            Context.Name = name;
            return this;
        }

        public IServiceConfigurator LifeTime(LifeTime lifeTime)
        {
            Context.Lifetime = lifeTime;
            return this;
        }

        public IServiceInterception Intercept { get { return interception; } }

        public IServiceConfigurator InterceptMethod(MethodInteception methodInteception)
        {
            Context.Interceptors.Add(methodInteception);
            return this;
        }
    }
}