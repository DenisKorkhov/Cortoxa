using System;
using Cortoxa.IoC.Base;

namespace Cortoxa.IoC.Service
{
    public static class Registration
    {
        public static IRegistrationStratagy Stratagy(this IToolRegistrator registration, Action<IToolRegistrator> registerator)
        {
            return new RegistrationStratagy(registerator);
        }
    }
}