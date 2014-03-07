using System;
using Cortoxa.IoC;
using Cortoxa.IoC.Base;
using Cortoxa.IoC.Base.ServiceFamily;
using Cortoxa.IoC.Common;

namespace Cortoxa.Components
{
    public interface IToolComponent<T> : IRegistrationStratagy where T : class, new()
    {
        void Add(Action<IServiceBuilderFor> serviceAction);

        IToolComponent<T> Configure(Action<T> configurationAction);
    }

//    public interface IToolComponent
//    {
//        void Configure<T>(Action<T> configurationAction);
//    }

    public interface IComponentSetup
    {
        IToolContainer Register { get; }
    }

    public interface IServiceComponent
    {
//        IServiceBuilder Register { get; set; }

//        void Register();
    }
}