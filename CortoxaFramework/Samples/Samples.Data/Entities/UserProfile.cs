using System;
using Cortoxa.Data.Identity.Entitites;
using Cortoxa.Data.Model;

namespace Samples.Data.Entities
{
    public class UserProfile : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}