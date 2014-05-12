using System;
using System.Reflection;
using Cortoxa.Configuration;
using Cortoxa.Container.Component;

namespace Cortoxa.Web.MVC.Controllers
{
    public static class ControllerExtentions
    {

        public static IComponentConfigurator<ControllersContext> AssemblyCalling(this IComponentConfigurator<ControllersContext> configurator)
        {
            return configurator.Assembly(System.Reflection.Assembly.GetCallingAssembly());
        }

        public static IComponentConfigurator<ControllersContext> AssemblyWithType<T>(this IComponentConfigurator<ControllersContext> configurator)
        {
            return configurator.AssemblyWithType(typeof(T));
        }

        public static IComponentConfigurator<ControllersContext> AssemblyWithType(this IComponentConfigurator<ControllersContext> configurator, Type type)
        {
            return configurator.Assembly(type.Assembly);
        }

        public static IComponentConfigurator<ControllersContext> Assembly(this IComponentConfigurator<ControllersContext> configurator, Assembly assembly)
        {
            configurator.Configure(c => c.Assemblies.Add(assembly));
            return configurator;
        }
    }
}