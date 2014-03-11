using Cortoxa.Components;
using Cortoxa.Container.Services;

namespace Cortoxa.NLog
{
    public class LoggerComponent : IComponent
    {
        public IServiceConfigurator Logger { get; set; }

    }
}