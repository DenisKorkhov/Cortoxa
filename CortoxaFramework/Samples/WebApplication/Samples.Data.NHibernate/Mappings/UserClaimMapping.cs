using Cortoxa.Identity.Entitites;

namespace Samples.Data.NHibernate.Mappings
{
    public class UserClaimMapping : BaseClassMapping<IdentityUserClaim>
    {
        public UserClaimMapping()
        {
            Property(x=>x.ClaimType);
            Property(x => x.ClaimValue);

            ManyToOne(x => x.User, x => x.Column("UserId"));
        }
    }
}