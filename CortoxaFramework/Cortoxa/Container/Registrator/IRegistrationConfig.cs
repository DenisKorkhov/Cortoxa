using Cortoxa.Container.Life;

namespace Cortoxa.Container.Registrator
{
    public interface IRegistrationConfig
    {
        IRegistrationConfig Name(string name);

        IRegistrationConfig LifeTime(LifeTime lifeTime);
         
    }
}