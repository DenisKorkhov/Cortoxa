using System;
using Cortoxa.IoC.Base;
using Cortoxa.IoC.Common;
using Cortoxa.IoC.Service;

namespace Cortoxa.IoC.Registration
{
    public class ServiceBuilder : IServiceBuilder, IRegistrationBuilder<ServiceConfiguration>//, IRegistrationStratagy
    {
        #region Fields

        private readonly ServiceConfiguration configuration = new ServiceConfiguration(); 

        #endregion

        #region Constructors

        internal ServiceBuilder(Type forType) : this(new[] { forType }) { }

        internal ServiceBuilder(Type[] forTypes)
        {
            configuration.For = forTypes;
        }

        #endregion

        public IServiceBuilder To<T>()
        {
            return To(typeof (T));
        }

        public IServiceBuilder To(Type to)
        {
            configuration.To = to;
            return this;
        }

        public IServiceBuilder Name(string name)
        {
            configuration.Name = name;
            return this;
        }

        public IServiceBuilder LifeTime(LifeTime lifeTime)
        {
            configuration.Lifetime = lifeTime;
            return this;
        }

        public void Register(Action<ServiceConfiguration> serviceRegistration)
        {
            serviceRegistration(configuration);
        }
    }
}