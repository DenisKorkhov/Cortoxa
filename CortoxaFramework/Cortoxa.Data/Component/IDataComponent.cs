using Cortoxa.Components;
using Cortoxa.Container.Services;
using Cortoxa.Data.Common;

namespace Cortoxa.Data.Component
{
    public interface IDataComponent : IComponent
    {
        IDataSource Source { get; set; }
    }
}