using System;
using Cortoxa.Configuration;
using Cortoxa.Container.Life;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Container.Types
{
    public class TypeConfigurator : Configurator<TypeContext>, ITypeConfigurator
    {
        public IRegistrationConfigurator Name(string name)
        {
            this.Configure(x=>x.Name = name);
            return this;
        }

        public IRegistrationConfigurator LifeTime(LifeTime lifeTime)
        {
            this.Configure(x => x.LifeTime = lifeTime);
            return this;
        }

        public ITypeConfigurator Where(Func<Type, bool> action)
        {
            this.Configure(x => x.Where = action);
            return this;
        }
    }
}