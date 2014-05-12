using System;
using System.Collections.Generic;
using Cortoxa.Configuration;
using Cortoxa.Container.Services;
using Cortoxa.Container.Types;

namespace Cortoxa.Container.Registrator
{
    public class ToolRegistrator : IRegistration
    {
        #region Fields

        private readonly IList<Action> registrationActions = new List<Action>();
        private readonly IConfigurationStrategy<ServiceContext> serviceRegistration;
        private readonly IConfigurationStrategy<TypeContext> typeRegistration;

        #endregion

        public ToolRegistrator(IConfigurationStrategy<ServiceContext> serviceRegistration, IConfigurationStrategy<TypeContext> typeRegistration)
        {
            this.serviceRegistration = serviceRegistration;
            this.typeRegistration = typeRegistration;
        }

        #region Implementation of IRegistration

        public IServiceConfigurator For(Type[] types)
        {
            var configurator = new ServiceConfigurator();
            configurator.Setup(c => c(new ServiceContext {For = types}));
            configurator.ConfigureBuild(s => this.serviceRegistration.Execute(s));
            registrationActions.Add(() => configurator.Build());
            return configurator;
        }

        public IAssemblyTypeConfigurator Type()
        {
            var configurator = new TypeConfigurator();
            configurator.Setup(c => c(new TypeContext()));
            configurator.ConfigureBuild(s => this.typeRegistration.Execute(s));
            registrationActions.Add(() => configurator.Build());
            return configurator;
        }

        #endregion

        public void Register()
        {
            foreach (var registrationAction in registrationActions)
            {
                registrationAction();
            }
        }
    }
}