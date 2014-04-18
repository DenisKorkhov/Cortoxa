using System;
using System.Collections.Generic;

namespace Cortoxa.Configuration
{
    public class Configurator<T> : IConfigurator<T>, IConfiguratorBuilder<T>
    {
        #region Fields
        
        protected Action<Action<T>> SetupStrategy;
        private readonly IList<Action<T>> configurations = new List<Action<T>>();
        private Action<T> buildStrategy;

        #endregion

        #region Implementation of IConfigurator<T>

        public void Setup(Action<Action<T>> contextAction)
        {
            this.SetupStrategy = contextAction;
        }

        public virtual void Configure(Action<T> action)
        {
            configurations.Add(action);
        }

        public virtual void ConfigureBuild(Action<T> buildStrategy)
        {
            this.buildStrategy = buildStrategy;
        }

        public virtual T Build()
        {
            T context = default(T);
            if (this.SetupStrategy != null)
            {
                this.SetupStrategy(c => context = c);
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