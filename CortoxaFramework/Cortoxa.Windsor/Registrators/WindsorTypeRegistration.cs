using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Cortoxa.Configuration;
using Cortoxa.Container.Types;
using Cortoxa.Windsor.Helpers;

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
            if (context.Assemblies != null && context.Assemblies.Any())
            {
                foreach (var assembly in context.Assemblies)
                {
                    var types = Types.FromAssembly(assembly).Where(t => context.Where(t));
                    types = types.ToWindsorLifeTime(context.LifeTime);

                    switch (context.ServiceSource)
                    {
                        case TypeServiceSourceEnum.Interface:
                            types = types.WithServiceFromInterface();
                            break;
                        case TypeServiceSourceEnum.FirstInterface:
                            types = types.WithServiceFromInterface();
                            break;
                        case TypeServiceSourceEnum.AllInterfaces:
                            types = types.WithServiceFromInterface();
                            break;
                        default:
                            types = types.WithServiceSelf();
                            break;
                    }
                    container.Register(types);
                }
            }
        }
    }
}