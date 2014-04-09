using System;

namespace Cortoxa.Configuration
{
    public class Configurator<T> : IConfigurator<T>, IConfiguratorBuilder<T>
    {
        #region Fields
        
        private Action<Action<T>> strategy;
        private Action<T> configuration;
        private Action<T> buildStrategy;

        #endregion

        #region Implementation of IConfigurator<T>

        public void Setup(Action<Action<T>> contextAction)
        {
            this.strategy = contextAction;
        }

        public void Configure(Action<T> action)
        {
            this.configuration = action;
        }

        public void OnBuild(Action<T> buildStrategy)
        {
            this.buildStrategy = buildStrategy;
        }

        public virtual T Build()
        {
            T context = default(T);
            if (this.strategy != null)
            {
                this.strategy(c => context = c);
            }

            if (this.configuration != null)
            {
                this.configuration(context);
            }

            if (this.buildStrategy != null)
            {
                buildStrategy(context);
            }
            return context;
        } 

        #endregion
    }
};