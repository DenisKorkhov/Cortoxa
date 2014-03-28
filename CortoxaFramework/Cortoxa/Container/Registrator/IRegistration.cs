using System;
using System.Reflection;
using Cortoxa.Container.Services;
using Cortoxa.Container.Types;

namespace Cortoxa.Container.Registrator
{
    public interface IRegistration
    {
        IServiceConfiguration For(params Type[] types);

        TypeConfiguration Types(params Assembly[] assemblies);
    }
}