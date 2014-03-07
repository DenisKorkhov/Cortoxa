using System;
using Cortoxa.IoC.Base;
using Cortoxa.IoC.Common;

namespace Cortoxa.IoC.Service
{
    public class RegistrationStratagy : IRegistrationStratagy
    {
        private readonly Action<IToolContainer> registrationAction;

        public RegistrationStratagy(Action<IToolContainer> registrationAction)
        {
            this.registrationAction = registrationAction;
        }

        public void Register(IToolContainer registrator)
        {
            registrationAction(registrator);
        }
    }
}