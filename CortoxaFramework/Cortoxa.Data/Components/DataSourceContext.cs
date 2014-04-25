using Cortoxa.Container;
using Cortoxa.Container.Services;

namespace Cortoxa.Data.Components
{
    public class DataSourceContext : LifeTimeContext
    {
        public IServiceConfigurator DataSource { get; set; }

        public IServiceConfigurator ModelBuilder { get; set; }

        public string ConnectionString { get; set; }
    }
}