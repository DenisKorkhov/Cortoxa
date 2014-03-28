using Cortoxa.Configuration;

namespace Cortoxa.Container.Types
{
    public class TypeConfiguration : ConfigurationBase<TypeContext>
    {
        public TypeConfiguration() : base(new TypeContext())
        {
        }


    }
}