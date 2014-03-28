using System;
using Cortoxa.Configuration;

namespace Cortoxa.Container.Components
{
    public class ComponentConfiguration : ConfigurationBase<IComponentContext>
    {
//        public ComponentConfiguration(IConfigurationStrategy<IComponentContext> strategy) //: base(strategy)
//        {
//        }

        public ComponentConfiguration(IComponentContext context) : base(context)
        {
        }
    }
}