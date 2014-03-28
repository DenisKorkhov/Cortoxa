using System;
using Cortoxa.Tool;

namespace Cortoxa.Configuration
{
    public class ConfigurationBase<T> : IConfiguration<T>
    {
        protected T context;
        private Action<T> configurationBuilder;

        public ConfigurationBase(T context)
        {
            this.context = context;
        }

        public void SetBuilder(Action<T> buildAction)
        {
            configurationBuilder = buildAction;
        }

        public void SetStrategy(IConfigurationStrategy<T> strategy)
        {
            configurationBuilder = strategy.Execute;
        }

        public void Configure(Action<T> contextAction)
        {
            contextAction(context);
        }

        public virtual T Build()
        {
            if (configurationBuilder != null)
            {
                configurationBuilder(context);
            }
            return context;
        }
    }
}