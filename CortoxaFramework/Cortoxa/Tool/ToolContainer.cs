using Cortoxa.Container;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Tool
{
    public class ToolContainer : IToolContainer
    {
        public ToolContainer(IRegistrator register)
        {
            Register = register;
        }

        public IRegistrator Register { get; private set; }
    }
}