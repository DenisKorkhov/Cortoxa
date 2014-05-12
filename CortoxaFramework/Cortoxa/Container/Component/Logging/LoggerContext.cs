using Cortoxa.Container.Life;

namespace Cortoxa.Container.Component.Logging
{
    public class LoggerContext : ILifeTimeContext
    {
        public string Name { get; set; }
        public LifeTime LifeTime { get; set; }
    }
}