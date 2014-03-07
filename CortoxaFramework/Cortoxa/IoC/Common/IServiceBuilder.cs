using System;
using Cortoxa.IoC.Base;
using Cortoxa.IoC.Registration;

namespace Cortoxa.IoC.Common
{
    public interface IServiceBuilder 
    {
        IServiceBuilder To<T>();

        IServiceBuilder To(Type to);

        IServiceBuilder Name(string name);

        IServiceBuilder LifeTime(LifeTime lifeTime);
    }
}