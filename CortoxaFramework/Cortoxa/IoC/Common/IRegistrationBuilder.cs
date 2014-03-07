using System;

namespace Cortoxa.IoC.Common
{
    public interface IRegistrationBuilder<T> where T : IRegistrationContext
    {
        void Register(Action<T> serviceRegistration);
    }
}