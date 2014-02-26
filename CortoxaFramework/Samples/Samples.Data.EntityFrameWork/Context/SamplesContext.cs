using System.Data.Entity;
using Samples.Data.Entities;

namespace Samples.Data.EntityFramework.Context
{
    public class SamplesContext : DbContext
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}