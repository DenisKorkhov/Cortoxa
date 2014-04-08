using System;

namespace Cortoxa.Configuration
{
    public class Configurator<T> : IConfiguratorBuilder<T>
    {
        #region Fields
        private readonly ConfigurationContext<T> context = new ConfigurationContext<T>();
        private Action<T> buildAction; 
        #endregion

        #region Impelementation of IConfiguratorBuilder

        public void SetBuilder(Action<T> buildAction)
        {
            this.buildAction = buildAction;
        }

        public T Build()
        {
            buildAction(context.Value);
            return context.Value;
        } 

        #endregion
    }
};