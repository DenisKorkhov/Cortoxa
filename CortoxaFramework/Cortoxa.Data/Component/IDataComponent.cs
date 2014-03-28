using Cortoxa.Components;
using Cortoxa.Data.Common;

namespace Cortoxa.Data.Component
{
    public interface IDataComponent : IComponent
    {
        IDataSource Source { get; set; }
    }
}