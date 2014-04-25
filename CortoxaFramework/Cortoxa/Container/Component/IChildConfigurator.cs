namespace Cortoxa.Container.Component
{
    public interface IChildConfigurator<TP> where TP : class
    {
        IComponentConfigurator<TP> Done();
    }
}