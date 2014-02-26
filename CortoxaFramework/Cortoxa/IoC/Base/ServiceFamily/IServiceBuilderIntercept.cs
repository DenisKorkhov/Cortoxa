namespace Cortoxa.IoC.Base.ServiceFamily
{
    public interface IServiceBuilderIntercept
    {
        IServiceInterception Intercept { get; } 
    }
}