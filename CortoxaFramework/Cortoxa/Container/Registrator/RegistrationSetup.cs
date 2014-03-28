using System;
using System.Collections.Generic;
using System.Reflection;
using Cortoxa.Configuration;
using Cortoxa.Container.Services;
using Cortoxa.Container.Types;

namespace Cortoxa.Container.Registrator
{
    public class RegistrationSetup : IRegistration
    {
        private readonly IConfigurationStrategy<ServiceContext> serviceRegistration;
        private readonly IConfigurationStrategy<TypeContext> typeRegistration;
        private readonly IList<Action> registrationAction = new List<Action>();

        public RegistrationSetup(IConfigurationStrategy<ServiceContext> serviceRegistration, IConfigurationStrategy<TypeContext> typeRegistration)
        {
            this.serviceRegistration = serviceRegistration;
            this.typeRegistration = typeRegistration;
        }

        public IServiceConfiguration For(params Type[] types)
        {
            var configuration = new ServiceConfiguration();
            registrationAction.Add(() => configuration.Build());
            return configuration;
        }

        public TypeConfiguration Types(params Assembly[] assemblies)
        {
            var configuration = new TypeConfiguration();
            registrationAction.Add(() => configuration.Build());
            return configuration;
        }

        public void Register()
        {
            foreach (var action in registrationAction)
            {
                action();
            }
        }
    }
}