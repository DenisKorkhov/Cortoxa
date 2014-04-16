using Cortoxa.Container.Component;
using Cortoxa.Data.Common;

namespace Cortoxa.Data.Component
{
    public interface IDataComponent 
    {
        IDataSource Source { get; set; }
    }
}