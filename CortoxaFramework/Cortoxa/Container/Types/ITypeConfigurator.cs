using System;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Container.Types
{
    public interface ITypeConfigurator : IRegistrationConfigurator
    {
        ITypeConfigurator Where(Func<Type, bool> action); 
    }
}