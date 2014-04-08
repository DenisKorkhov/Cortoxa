using System;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Container.Components
{
    public interface IComponentRegistratior
    {
        void Register(Action<IRegistrator> registrationAction);
    }
}