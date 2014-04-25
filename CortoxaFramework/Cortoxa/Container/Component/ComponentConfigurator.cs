using System;
using System.Collections.Generic;
using System.Linq;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Container.Component
{
    public class ComponentConfigurator<T> : IComponentConfigurator<T> where T : class, new()
    {
        private readonly IRegistration registration;

        #region Fields

        private readonly IList<Action<T>> configurations = new List<Action<T>>();
        private readonly IList<Action<T>> builds = new List<Action<T>>();
        private readonly T context;

        #endregion

        public ComponentConfigurator(IRegistration registration, T context = null)
        {
            this.registration = registration;
            this.context = context ?? new T();
        }

        public void Configure(Action<T> action)
        {
            configurations.Add(action);
        }

        public void Register(Action<IRegistration, T> registrationStrategy)
        {
            this.builds.Add(c=> registrationStrategy(registration, c));
        }

        public IComponentConfigurator<TC> Child<TC>(TC childContext, Action<T, TC> childSetup) where TC : class, new()
        {
            var childConfigurator = new ChildConfigurator<TC, T>(registration, this, childContext);
            this.builds.Add(c => childConfigurator.Build());
            return childConfigurator;
        }
        

        public void Build()
        {
            if (this.configurations != null)
            {
                foreach (var configuration in this.configurations)
                {
                    configuration(context);
                }
            }

            if (this.builds.Any())
            {
                foreach (var build in builds)
                {
                    build(context);
                }
            }
        }
    }
}