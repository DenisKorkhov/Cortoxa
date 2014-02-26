using Cortoxa.IoC.Base;

namespace Cortoxa.IoC.Service
{
    public class ServiceDependency : IServiceDependency
    {
        private readonly IServiceBuilder serviceBuilder;

        public ServiceDependency(IServiceBuilder serviceBuilder)
        {
            this.serviceBuilder = serviceBuilder;
        }

//        public static IServiceBuilder On<T>(string dependencyName)
//        {
//
////            return serviceBuilder.Depend;
//        }

//        public static IServiceBuilder On<T>(this IServiceBuilder service, string serviceName, string dependencyName)
//        {
//            return service;
//        }
         
    }
}