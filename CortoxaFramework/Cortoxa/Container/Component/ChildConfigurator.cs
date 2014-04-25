using Cortoxa.Container.Registrator;

namespace Cortoxa.Container.Component
{
    public class ChildConfigurator<T, TP> : ComponentConfigurator<T>, IChildConfigurator<TP> where T : class, new() where TP : class, new()
    {
        private readonly ComponentConfigurator<TP> parent;

        public ChildConfigurator(IRegistration registration, ComponentConfigurator<TP> parent, T context): base(registration, context ?? new T())
        {
            this.parent = parent;
        }

        public IComponentConfigurator<TP> Done()
        {
            return parent;
        }
    }
}