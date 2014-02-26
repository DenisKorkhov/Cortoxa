using System;

namespace Cortoxa.IoC.Base.ServiceFamily
{
    public interface IServiceBuilderTo : IServiceBuilderIntercept
    {
        IServiceBuilderRest To<T>();

        IServiceBuilderRest To(Type type);

        IServiceBuilderRest ToSelf();
    }
}