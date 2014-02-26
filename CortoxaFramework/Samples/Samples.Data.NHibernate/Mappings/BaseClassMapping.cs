using Cortoxa.Data;
using Cortoxa.Data.Common;
using Cortoxa.Data.Model;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Samples.Data.NHibernate.Mappings
{
    public abstract class BaseClassMapping<T> : ClassMapping<T> where T : class, IEntity
    {
        public BaseClassMapping()
        {
            Id(x=>x.Id, m => m.Generator(Generators.Guid));
        }
    }
}