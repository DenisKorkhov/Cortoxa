using System.Data.Entity;
using Samples.Data.Entities;

namespace Samples.Data.EntityFramework.Context
{
    public class SamplesContext : DbContext
    {
        #region Constructor

        protected SamplesContext()
        {

        }

        #endregion

        public SamplesContext(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}