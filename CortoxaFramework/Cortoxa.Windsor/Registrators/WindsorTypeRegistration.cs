using Castle.Windsor;
using Cortoxa.Configuration;
using Cortoxa.Container.Types;
using Cortoxa.Tool;

namespace Cortoxa.Windsor.Registrators
{
    public class WindsorTypeRegistration : IConfigurationStrategy<TypeContext>
    {
        private readonly IWindsorContainer container;

        public WindsorTypeRegistration(IWindsorContainer container)
        {
            this.container = container;
        }

        public void Execute(TypeContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}