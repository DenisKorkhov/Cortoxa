using System;
using System.Reflection;
using Cortoxa.Common.Configuration;
using Cortoxa.Configuration;
using Cortoxa.Container.Complex;
using Cortoxa.Container.Services;
using Cortoxa.Container.Types;

namespace Cortoxa.Container.Registrator
{
    public class ContainerConfigurator : IConfigurator<ActionContext>, IRegistration
    {
        private readonly IConfigurationStrategy<ServiceContext> serviceStrategy;
        private readonly IConfigurationStrategy<TypeContext> typeStrategy;
        private readonly ActionContext context;

        public ActionContext Context
        {
            get { return context; }
        }

        public ContainerConfigurator(IConfigurationStrategy<ServiceContext> serviceStrategy, IConfigurationStrategy<TypeContext> typeStrategy)
        {
            this.serviceStrategy = serviceStrategy;
            this.typeStrategy = typeStrategy;
            context = new ActionContext();
        }

        public IServiceConfiguration For(params Type[] types)
        {
            var configurator = new ServiceConfiguration();
            configurator.Configure(x=>x.For = types);
//            context.ConfiurationActions.Add(configurator.Build);
            return configurator;
        }

        public TypeConfiguration Types(params Assembly[] assemblies)
        {
            var configurator = new TypeConfiguration();
//            context.ConfiurationActions.Add(configurator.Build);
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