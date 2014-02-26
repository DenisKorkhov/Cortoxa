using System;
using Cortoxa.IoC.Base.ServiceFamily;

namespace Cortoxa.IoC.Base
{
    public interface IServiceBuilderFor
    {
        IServiceBuilderTo For(Type serviceType);
        IServiceBuilderTo For(Type[] serviceTypes);
        IServiceBuilderTo For<T>();
        IServiceBuilderTo For<T, T2>();
        IServiceBuilderTo For<T, T2, T3>();
        IServiceBuilderTo For<T, T2, T3, T4>(); 
    }
}