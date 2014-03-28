using System;
using Cortoxa.Container.Life;

namespace Cortoxa.Container.Services
{
    public interface IServiceConfiguration
    {
        IServiceConfiguration To<T>();

        IServiceConfiguration To(Type to);

        IServiceConfiguration Name(string name);

        IServiceConfiguration LifeTime(LifeTime lifeTime);

        IServiceInterception Intercept { get; }

        IServiceConfiguration InterceptMethod(MethodInteception methodInteception);

        IServiceConfiguration ToFactory(Func<FactoryContext, object> action); 
    }
}