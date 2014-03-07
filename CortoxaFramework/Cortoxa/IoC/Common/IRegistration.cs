using System;
using Cortoxa.IoC.Component;
using Cortoxa.IoC.Service;


namespace Cortoxa.IoC.Common
{
    public interface IRegistration
    {
        IServiceBuilder For(params Type[] types);

        IComponentBuilder Component<T>(Action<ISetupConfigurator<T>> action);

//        TypeRegistration Types();
    }
}