
using Cortoxa.Container.Registrator;

namespace Cortoxa.Configuration
{
    public abstract class RegistrationConfigurator<T> : Configurator<T>, IRegistrationConfigurator<T>
    {
        public RegistrationConfigurator(IRegistration registrator, T context)
        {
            this.Setup(c => c(context));
            this.ConfigureBuild(c=>Register(registrator, c));
        }

        protected abstract void Register(IRegistration registrator, T context);
    }
}