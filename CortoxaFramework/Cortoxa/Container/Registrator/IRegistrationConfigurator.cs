using Cortoxa.Container.Life;

namespace Cortoxa.Container.Registrator
{
    public interface IRegistrationConfigurator
    {
        IRegistrationConfigurator Name(string name);

        IRegistrationConfigurator LifeTime(LifeTime lifeTime);
         
    }
}