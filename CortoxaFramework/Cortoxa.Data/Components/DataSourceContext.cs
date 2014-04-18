using Cortoxa.Container;

namespace Cortoxa.Data.Components
{
    public class DataSourceContext : LifeTimeContext
    {
        public string ConnectionString { get; set; }
        
    }
}