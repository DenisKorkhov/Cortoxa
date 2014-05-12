using System.Linq;
using Cortoxa.Common;
using Cortoxa.Configuration;
using Cortoxa.Container.Registrator;
using Cortoxa.Web.MVC.Controllers;

namespace Cortoxa.Web.MVC.Container
{
    public class ControllerConfigurator : RegistrationConfigurator<ControllersContext>
    {
        public ControllerConfigurator(IRegistration registrator) : base(registrator, new ControllersContext())
        {
        }

        protected override void Register(IRegistration registrator, ControllersContext context)
        {
            registrator.Type().Assemblies(context.Assemblies.ToArray()).Where(x => x.BasedOn(context.ControllerType)).LifeTime(context.LifeTime);
        }
    }
}