using System;
using System.Collections.Generic;
using System.Linq;

namespace Cortoxa.Configuration
{
    public class Configurator<T> : IConfigurator<T>, IConfiguratorBuilder<T>
    {
        #region Fields
        
        protected Action<Action<T>> SetupStrategy;
        private readonly IList<Action<T>> configurations = new List<Action<T>>();
        private IList<Action<T>> buildStrategies = new List<Action<T>>();

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
            buildStrategies.Add(buildStrategy);
//            this.buildStrategy = buildStrategy;
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

            if (this.buildStrategies.Any())
            {
                foreach (var buildStrategy in buildStrategies)
                {
                    buildStrategy(context);    
                }
            }
            return context;
        } 

        #endregion
    }
};