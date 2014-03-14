using Cortoxa.Data.Model;

namespace Samples.Data.Entities
{
    public class UserProfile : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public User User { get; set; }
    }
}