using System.Data.Entity;
using Cortoxa.Container.Services;
using Cortoxa.Data.Common;
using Cortoxa.Data.Component;

namespace Cortoxa.Data.EntityFramework.Component
{
    public class EntityComponent : IDataComponent
    {
        public IServiceConfigurator Context { get; set; }

        public IDataSource Source { get; set; }
    }
}