using Cortoxa.Container.Registrator;

namespace Cortoxa.Container.Component
{
    public interface IComponentConfigurator<T> where T : class, new()
    {
        IRegistration Registrator { get; }
    }
}