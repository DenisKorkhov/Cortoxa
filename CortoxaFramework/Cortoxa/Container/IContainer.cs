using Cortoxa.Container.Registrations;

namespace Cortoxa.Container
{
    public interface IContainer
    {
        IContainerRegistrator Register { get; }

        IContainerResolver Resolver { get; }

        IContainerCleanup Cleanup { get; }
    }
}