using System;
using System.Collections.Generic;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Container.Component
{
    public class ComponentSetup<T> : IComponentSetup<T> where T : class
    {
        #region Fields
        private readonly IRegistration registration; 
        private readonly IList<Action> buildActions = new List<Action>();
        #endregion


        #region Constructor
        public ComponentSetup(IRegistration registration)
        {
            this.registration = registration;
        } 
        #endregion

        #region IComponentSetup<T>

        public IComponentConfigurator<TK> Setup<TK>(Func<TK> setupnContext, Action<IRegistration, TK> setupAction) where TK : class, new()
        {
            var contextType = typeof(TK);
            var confuguratorType = typeof(ComponentConfigurator<>).MakeGenericType(contextType);
            var configurator = Activator.CreateInstance(confuguratorType, new object[] { registration, new TK() }) as ComponentConfigurator<TK>;
            if (configurator == null)
            {
                throw new InvalidCastException();
            }
            
            configurator.Register(setupAction);
            buildActions.Add(configurator.Build);
            return configurator;
        } 

        #endregion

        public void Build()
        {
            foreach (var buildAction in buildActions)
            {
                buildAction();
            }
        }
    }
}