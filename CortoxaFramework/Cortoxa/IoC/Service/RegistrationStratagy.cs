using System;
using Cortoxa.IoC.Base;

namespace Cortoxa.IoC.Service
{
    public class RegistrationStratagy : IRegistrationStratagy
    {
        private readonly Action<IToolRegistrator> registrationAction;

        public RegistrationStratagy(Action<IToolRegistrator> registrationAction)
        {
            this.registrationAction = registrationAction;
        }

        public void Register(IToolRegistrator registrator)
        {
            registrationAction(registrator);
        }
    }
}