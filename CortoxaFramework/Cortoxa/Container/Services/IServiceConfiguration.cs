using System;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Container.Services
{
    public interface IServiceConfiguration : IRegistrationConfig
    {
        IServiceConfiguration To<T>();

        IServiceConfiguration To(Type to);

        IServiceInterception Intercept { get; }

        IServiceConfiguration InterceptMethod(MethodInteception methodInteception);

        IServiceConfiguration ToFactory(Func<FactoryContext, object> action); 
    }
}