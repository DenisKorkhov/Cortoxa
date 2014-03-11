namespace Cortoxa.Common.Configuration
{
    public interface IConfigurator<T> : IConfigurator
    {
        T Context { get; }
    }

    public interface IConfigurator
    {
        void Configure();
    }
}