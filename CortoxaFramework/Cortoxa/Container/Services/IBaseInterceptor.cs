namespace Cortoxa.Container.Services
{
    public interface IBaseInterceptor
    {
        void Intercept(InterceptionContext context); 
    }
}