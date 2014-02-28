using Cortoxa.Data.Component;
using Cortoxa.IoC.Base.ServiceFamily;

namespace Cortoxa.Data.EntityFramework.Component
{
    public class EntityComponent : IDataComponent
    {

        public IServiceBuilder DbContext { get; private set; }

        public IServiceBuilder DataSource { get; private set; }
    }
}