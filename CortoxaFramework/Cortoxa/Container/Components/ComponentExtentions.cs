using System;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Container.Components
{
    public static class ComponentExtentions
    {
        public static void Component(this IRegistration registration, Action<IComponentRegistrator> configurationAction)
        {
            var configurator = new ComponentRegistrator(registration);
            configurationAction(configurator);
            configurator.Configure();
        }
    }
}