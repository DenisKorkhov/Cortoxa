using Cortoxa.Configuration;

namespace Cortoxa.Container.Configuration
{
    public interface IContainerConfiguration<T> : IConfiguration<T>
    {
        IToolContainer Conteiner { get; }
    }
}