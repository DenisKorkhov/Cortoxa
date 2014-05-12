using System;
using System.Reflection;

namespace Cortoxa.Container.Types
{
    public interface IAssemblyTypeConfigurator
    {
        ITypeConfigurator Assemblies(Assembly[] assemblies);
    }
}