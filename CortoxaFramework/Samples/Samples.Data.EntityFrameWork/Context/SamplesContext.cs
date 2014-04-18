using System.Data.Entity;
using Samples.Data.Entities;

namespace Samples.Data.EntityFramework.Context
{
    public class SamplesContext : DbContext
    {
        #region Constructor
        public SamplesContext(string connectionString): base(connectionString)
        {
        }
        #endregion

        public DbSet<User> Users { get; set; }


    }
}