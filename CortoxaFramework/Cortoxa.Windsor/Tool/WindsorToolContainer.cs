using System;
using Castle.Windsor;
using Cortoxa.Container;
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
            this.resolver = new WindsorResolver(container);

        }

        public IToolContainer Register(Action<IRegistration> regAction)
        {
            var registrator = new ToolRegistrator(new WindsorServiceRegistration(container), new WindsorTypeRegistration(container));
            regAction(registrator);
            registrator.Register();
            return this;
        }

        public IResolver Resolver
        {
            get { return this.resolver; }
        }
    }
}