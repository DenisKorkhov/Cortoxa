using Cortoxa.Data.Model;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Cortoxa.Data.NHibernate.Mappings
{
    public class EntityMapping<T> : ClassMapping<T> where T  : Entity
    {
        public EntityMapping()
        {
            Schema("dbo");

            Id(x => x.Id, map => map.Generator(Generators.Guid));
        }
    }
}