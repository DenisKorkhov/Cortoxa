using System;
using System.Collections.Generic;
using Cortoxa.Configuration;
using Cortoxa.Container.Services;
using Cortoxa.Container.Types;

namespace Cortoxa.Container.Configuration
{
    public class ContainerConfiguration 
    {
        private readonly IConfigurationStrategy<ServiceContext> serviceStrategy;
        private readonly IConfigurationStrategy<TypeContext> typeStrategy;

        private IList<Action> registrationActions = new List<Action>();


        public ContainerConfiguration(IConfigurationStrategy<ServiceContext> serviceStrategy, IConfigurationStrategy<TypeContext> typeStrategy)
        {
            this.serviceStrategy = serviceStrategy;
            this.typeStrategy = typeStrategy;
        }
    }
}