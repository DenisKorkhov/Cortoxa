using System;
using System.Collections.Generic;

namespace Cortoxa.Configuration
{
    public class Configurator<T> : IConfigurator<T>, IConfiguratorBuilder<T>
    {
        #region Fields
        
        private Action<Action<T>> strategy;
        private readonly IList<Action<T>> configurations = new List<Action<T>>();
        private Action<T> buildStrategy;

        #endregion

        #region Implementation of IConfigurator<T>

        public void Setup(Action<Action<T>> contextAction)
        {
            this.strategy = contextAction;
        }

        public void Configure(Action<T> action)
        {
            configurations.Add(action);
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

            if (this.configurations != null)
            {
                foreach (var configuration in this.configurations)
                {
                    configuration(context);
                }
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