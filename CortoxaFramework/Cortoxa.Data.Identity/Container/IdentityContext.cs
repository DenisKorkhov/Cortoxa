using System;
using Cortoxa.Container.Component;
using Cortoxa.Container.Life;

namespace Cortoxa.Data.Identity.Container
{
    public class IdentityContext : ILifeTimeContext
    {
        public Type UserType { get; set; }

        public Type RoleType { get; set; }

        public Type ClaimType { get; set; }

        public string DataSource { get; set; }

        public string Name { get; set; }

        public LifeTime LifeTime { get; set; }
    }
}