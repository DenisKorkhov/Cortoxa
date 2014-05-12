using Cortoxa.Container.Life;

namespace Cortoxa.Container.Component
{
    public interface ILifeTimeContext
    {
        string Name { get; set; }

        LifeTime LifeTime { get; set; } 
    }
}