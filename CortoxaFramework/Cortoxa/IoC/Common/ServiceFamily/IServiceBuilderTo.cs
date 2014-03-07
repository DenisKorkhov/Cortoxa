using System;

namespace Cortoxa.IoC.Base.ServiceFamily
{
    public interface IServiceBuilderTo : IServiceBuilderIntercept
    {
        IServiceBuilderCommon To<T>();

        IServiceBuilderCommon To(Type type);

        IServiceBuilderCommon ToSelf();
    }
}