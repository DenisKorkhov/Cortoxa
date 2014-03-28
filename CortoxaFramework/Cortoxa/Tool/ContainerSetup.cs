using Cortoxa.Configuration;

namespace Cortoxa.Tool
{
    public class ContainerSetup : ConfigurationBase<ContainerContext>
    {
        public ContainerSetup(ContainerContext context) : base(context)
        {
        }
    }
}