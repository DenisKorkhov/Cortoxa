using System;
using Cortoxa.IoC.Base;
using Cortoxa.IoC.Base.ServiceFamily;

namespace Cortoxa.Components
{
    public interface IToolComponent<T>  : IRegistrationStratagy where T : IServiceComponent 
    {
        void Add(Action<IServiceBuilderFor> serviceAction);
    }

    public interface IServiceComponent
    {
        IServiceBuilder Service { get; set; }

//        void Register();
    }
}