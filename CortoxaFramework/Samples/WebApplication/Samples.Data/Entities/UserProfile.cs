using System;
using Cortoxa.Identity.Entitites;

namespace Samples.Data.Entities
{
    public class UserProfile
    {
        public Guid UserId { get; set; }

        public IdentityUser User { get; set; }
    }
}