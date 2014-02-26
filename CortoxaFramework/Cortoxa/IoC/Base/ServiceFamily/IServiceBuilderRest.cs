using Cortoxa.IoC.Interception;

namespace Cortoxa.IoC.Base.ServiceFamily
{
    public interface IServiceBuilderRest : IServiceBuilderIntercept
    {

        IServiceBuilder Name(string name);

        IServiceBuilder LifeTime(LifeTime lifeTime);

        IServiceBuilder InterceptMethod(MethodInteception methodInteceptor);

        IServiceBuilder DependOn(string name);


//        IServiceBuilder DependOn(Type type, string dependencyName); 
    }
}