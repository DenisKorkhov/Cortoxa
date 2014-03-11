namespace Cortoxa.Common.Configuration
{
    public interface IConfigurationStrategy<T>
    {
        void Configure(T context);
    }
}