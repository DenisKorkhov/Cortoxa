using System.Runtime.InteropServices;

namespace Cortoxa.Common.Configuration
{
    public abstract class BaseConfigurator<T> : IConfigurator<T>
    {
        private readonly IConfigurationStrategy<T> strategy;
        private readonly T context;

        protected BaseConfigurator(IConfigurationStrategy<T> strategy, T context)
        {
            this.strategy = strategy;
            this.context = context;
        }

        public T Context
        {
            get { return context; }
        }

        public void Configure()
        {
            strategy.Configure(Context);
        }
    }
}