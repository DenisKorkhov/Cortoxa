//using Cortoxa.Data.Identity.Entitites;
//using NHibernate.Mapping.ByCode;
//using Samples.Data.Entities;

namespace Samples.Data.NHibernate.Mappings
{
    public class UserMapping// : BaseClassMapping<IdentityUser>
    {
        public UserMapping()
        {
//            Property(x => x.UserName);
//            Property(x => x.PasswordHash);
//            Property(x => x.SecurityStamp);
//
//            Set(x=>x.Roles, collection =>
//            {
//                collection.Table("IdentityUserRoles");
//                collection.Key(c => c.Column("UserId"));
//            },
//            map => map.ManyToMany(c => c.Column("RoleId")));
//
//            Set(x => x.Claims, mapping =>
//            {
//                mapping.Key(k => k.Column("UserId"));
//                mapping.Inverse(true);
//            },
//            r => r.OneToMany());
        }
    }
}
