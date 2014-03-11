using Castle.Windsor;
using Cortoxa.Common.Configuration;
using Cortoxa.Container.Types;

namespace Cortoxa.Windsor.Registrators
{
    public class WindsorTypeRegistrator : IConfigurationStrategy<TypeContext>//: IRegistratorBuilder<string>
    {
        private readonly IWindsorContainer container;

        public WindsorTypeRegistrator(IWindsorContainer container)
        {
            this.container = container;
        }

        public void Configure(TypeContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}