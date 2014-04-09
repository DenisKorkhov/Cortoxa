using System;

namespace Cortoxa.Configuration
{
    public class Configurator<T> : IConfigurator<T>
    {
        #region Fields
        
        private Action<Action<T>> strategy;
        private Action<T> configuration;

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

        public T Build()
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
            return context;
        } 

        #endregion
    }
};