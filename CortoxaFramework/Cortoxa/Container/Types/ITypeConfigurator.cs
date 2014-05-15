using System;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Container.Types
{
    public interface ITypeConfigurator : IAssemblyTypeConfigurator, IRegistrationConfigurator
    {
        ITypeConfigurator Where(Func<Type, bool> action);

        ITypeConfigurator ServiceSource(TypeServiceSourceEnum serviceSource);
    }
}