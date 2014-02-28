using Cortoxa.Components;
using Cortoxa.IoC.Base.ServiceFamily;

namespace Cortoxa.Data.Component
{
    public interface IDataComponent : IServiceComponent
    {
        IServiceBuilder DbContext { get;  }

        IServiceBuilder DataSource { get;  }
    }
}