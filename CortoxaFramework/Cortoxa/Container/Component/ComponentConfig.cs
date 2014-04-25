using System.Collections.Generic;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Container.Component
{
    public abstract class ComponentConfig
    {
        #region Fields

        protected readonly IDictionary<string, IRegistrationConfigurator> Registrators = new Dictionary<string, IRegistrationConfigurator>(); 

        #endregion

        #region MyRegion

        public IRegistrationConfigurator GetRegistrators(string name)
        {
            return Registrators[name];
        } 

        #endregion
    }
}