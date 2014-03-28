using Cortoxa.Container;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Tool
{
    public class ToolWizard : IToolWizard
    {
        private readonly IToolContainer container;

        public ToolWizard(IToolContainer container)
        {
            this.container = container;
        }

        public IRegistration Register { get; private set; }
    }
}