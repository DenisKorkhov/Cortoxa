using System;
using Cortoxa.Container.Common;

namespace Cortoxa.Container.Services
{
    public interface IServiceConfigurator 
    {
        IServiceConfigurator To<T>();

        IServiceConfigurator To(Type to);

        IServiceConfigurator Name(string name);

        IServiceConfigurator LifeTime(LifeTime lifeTime);

        IServiceInterception Intercept { get; }

        IServiceConfigurator InterceptMethod(MethodInteception methodInteception);
    }
}