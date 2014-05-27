﻿using System;
using System.Linq;
using Castle.Core;
using Castle.Windsor;
using Cortoxa.Common.Log;
using Cortoxa.Configuration;
using Cortoxa.Container;
using Cortoxa.Container.Component;
using Cortoxa.Container.Registrator;
using Cortoxa.Windsor.Registrators;

namespace Cortoxa.Windsor.Tool
{
    public class WindsorToolContainer : IToolContainer//, IRegistration
    {
        #region Fields

        private readonly IWindsorContainer container;
        private WindsorResolver resolver; 

        #endregion
        
        public WindsorToolContainer(IWindsorContainer container)
        {
            this.container = container;
            this.resolver = new WindsorResolver(container.Kernel);
        }

        public IToolContainer Register(Action<IRegistration> regAction)
        {
            var registrator = new ToolRegistrator(new WindsorServiceRegistration(container), new WindsorTypeRegistration(container));
            regAction(registrator);
            registrator.Register();
            return this;
        }

        public IToolContainer RegisterNative<T>(Action<T> registrator)
        {
            registrator((T)container);
            return this;
        }

        public IToolContainer Register<T>(Func<IRegistration, IComponentConfigurator<T>> regAction) where T : class
        {
            var registrator = new ToolRegistrator(new WindsorServiceRegistration(container), new WindsorTypeRegistration(container));
            var configurator = regAction(registrator);
            configurator.Build();
            registrator.Register();
            return this;
        }

        public IResolver Resolver
        {
            get { return this.resolver; }
        }

        public void Release(object instance)
        {
            container.Release(instance);
        }

        public void TraceDependencies()
        {
            var logger = this.container.Resolve<ILogger>();
            if (logger != null)
            {
                logger.Info("Trace Dependencies:");
                foreach (var graphNode in this.container.Kernel.GraphNodes)
                {
                    TraceNode(graphNode as ComponentModel, logger);
                }
                logger.Info("Trace Dependencies Finished!");
            }
        }

        private void TraceNode(ComponentModel component, ILogger logger, string indent = "")
        {
            var services = component.Services.Aggregate("", (current, service) => current + (service.FullName + ";"));
            logger.Info(string.Format("{3} {0} {1} {2}", component.Name, services, component.Implementation, indent));

            foreach (var depend in component.Dependents)
            {
                indent += "-";
                TraceNode(depend as ComponentModel, logger, indent);
            }
            
        }
    }
}