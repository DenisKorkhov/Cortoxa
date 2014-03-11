using System;
using System.Reflection;
using Cortoxa.Common.Configuration;
using Cortoxa.Container.Complex;
using Cortoxa.Container.Services;
using Cortoxa.Container.Types;

namespace Cortoxa.Container.Registrator
{
    public class ContainerConfigurator : IConfigurator<ComplexContext>, IRegistration
    {
        private readonly IConfigurationStrategy<ServiceContext> serviceStrategy;
        private readonly IConfigurationStrategy<TypeContext> typeStrategy;
        private readonly ComplexContext context;

        public ComplexContext Context
        {
            get { return context; }
        }

        public ContainerConfigurator(IConfigurationStrategy<ServiceContext> serviceStrategy, IConfigurationStrategy<TypeContext> typeStrategy)
        {
            this.serviceStrategy = serviceStrategy;
            this.typeStrategy = typeStrategy;
            context = new ComplexContext();
        }

        public IServiceConfigurator For(params Type[] types)
        {
            var configurator = new ServiceConfigurator(serviceStrategy);
            configurator.For(types);
            context.ConfiurationActions.Add(configurator.Configure);
            return configurator;
        }

        public ITypeConfigurator Types(params Assembly[] assemblies)
        {
            var configurator = new TypeConfigurator(typeStrategy);
            context.ConfiurationActions.Add(configurator.Configure);
            return configurator;
        }

        public void Configure()
        {
            foreach (var confiurationAction in this.Context.ConfiurationActions)
            {
                confiurationAction();
            }
        }
    }
}