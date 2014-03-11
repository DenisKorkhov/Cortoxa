using Cortoxa.Common.Configuration;

namespace Cortoxa.Container.Complex
{
    public class ComplexConfigurationStrategy : IConfigurationStrategy<ComplexContext>
    {
        public void Configure(ComplexContext context)
        {
            foreach (var configurationAction in context.ConfiurationActions)
            {
                configurationAction();
            }
        }
    }
}