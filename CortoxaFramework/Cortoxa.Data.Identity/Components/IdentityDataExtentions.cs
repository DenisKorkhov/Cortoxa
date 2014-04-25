using Cortoxa.Container.Component;
using Cortoxa.Container.Services;
using Cortoxa.Data.Components;

namespace Cortoxa.Data.Identity.Components
{
    public static class IdentityDataExtentions
    {

        public static IComponentConfigurator<IdentityConfig> WithIdentity<T>(this IComponentConfigurator<T> configurator) where T : DataSourceContext
        {
            configurator.Register((r, c) =>
            {

            });
            return configurator.Child(new IdentityConfig(), (d, identity) =>
            {
//                identity.
            });
        }

        public static IComponentConfigurator<IdentityConfig> User<T>(this IComponentConfigurator<IdentityConfig> configurator)
        {
            return configurator;
        }

        public static IComponentConfigurator<IdentityConfig> Role<T>(this IComponentConfigurator<IdentityConfig> configurator)
        {
            return configurator;
        }
    }

    public class IdentityConfig
    {

    }
}