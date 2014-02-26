using System;
using Cortoxa.IoC.Base;

namespace Cortoxa.Components
{
    public interface IToolComponent<T> : IRegistrationStratagy
    {
        void OnRegister(Action<IToolRegistrator> action);
//
//        IToolComponent<T> Named(string name);
        void AddRegistration(IRegistrationStratagy serviceRegistration);
    }
}