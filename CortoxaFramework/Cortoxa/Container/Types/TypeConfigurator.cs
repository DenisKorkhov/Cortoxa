using Cortoxa.Common.Configuration;

namespace Cortoxa.Container.Types
{
    public class TypeConfigurator : BaseConfigurator<TypeContext>, ITypeConfigurator
    {
        public TypeConfigurator(IConfigurationStrategy<TypeContext> strategy) : base(strategy, new TypeContext())
        {
        }
    }
}