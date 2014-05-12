using System;
using System.Reflection;
using Cortoxa.Container.Services;
using Cortoxa.Container.Types;

namespace Cortoxa.Container.Registrator
{
    public interface IRegistration
    {
        IServiceConfigurator For(Type[] types);

        IAssemblyTypeConfigurator Type();
    }
}