using System;

using Cortoxa.Container.Registrator;

namespace Cortoxa.Container.Components
{
    public static class ComponentExtentions
    {
        public static IRegistrator Component(this IRegistrator registrator, Action<Action<Action<IRegistrator>>> setup)
        {
            setup(c => c(registrator));
            return registrator;
        }
    }
}