using System;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Container.Services
{
    public interface IServiceConfigurator : IRegistrationConfigurator
    {
        IServiceConfigurator To<T>();

        IServiceConfigurator To(Type to);

        IServiceInterception Intercept { get; }

        IServiceConfigurator InterceptMethod(MethodInteception methodInteception);

        IServiceConfigurator ToFactory(Func<FactoryContext, object> action);

        IServiceConfigurator DependsOnComponent<T>(string componentName);

        IServiceConfigurator DependsOnValue(string name, object value);
    }
}