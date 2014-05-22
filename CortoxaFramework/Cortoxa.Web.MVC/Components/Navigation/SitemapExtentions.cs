using System;
using Cortoxa.Configuration;
using Cortoxa.Container.Component;
using Cortoxa.Container.Extentions;
using Cortoxa.Container.Life;
using Cortoxa.Container.Registrator;
using Cortoxa.Web.MVC.Components.Navigation.Contracts;
using Cortoxa.Web.MVC.Components.Navigation.Model;

namespace Cortoxa.Web.MVC.Components.Navigation
{
    public static class SitemapExtentions
    {
        public static IComponentConfigurator<SitemapContext> SiteMap(this IRegistration registration)
        {
            var componentConfigurator = new ComponentConfigurator<SitemapContext>(registration, new SitemapContext());
            componentConfigurator.Configure(c=>c.NodeType = typeof(SitemapNode));
            componentConfigurator.Register((r, c) =>
            {
                var readerServiceType = typeof (ISitemapReader<>).MakeGenericType(c.NodeType);
                var readerImplType = typeof (SitemapFileReader<>).MakeGenericType(c.NodeType);

                var managerServiceType = typeof (ISitemapManager<>).MakeGenericType(c.NodeType);
                var managerImplType = typeof (SitemapManager<>).MakeGenericType(c.NodeType);

                var readername = string.Format("sitemapreader_{0}", Guid.NewGuid().ToString());
                r.For(readerServiceType).To(readerImplType).DependsOnValue("path", c.Source).Name(readername).LifeTime(LifeTime.Singleton);
                r.For(managerServiceType).To(managerImplType).DependsOnComponent(readerServiceType, readername).LifeTime(LifeTime.Singleton);
            });
            return componentConfigurator;
        }

        public static IComponentConfigurator<SitemapContext> Node<T>(this IComponentConfigurator<SitemapContext> configurator)
        {
            return configurator.Node(typeof (T));
        }

        public static IComponentConfigurator<SitemapContext> Node(this IComponentConfigurator<SitemapContext> configurator, Type nodeType)
        {
            configurator.Configure(c=>c.NodeType = nodeType);
            return configurator;
        }

        public static IComponentConfigurator<SitemapContext> Source(this IComponentConfigurator<SitemapContext> configurator, string sitemapPath)
        {
            configurator.Configure(c => c.Source = sitemapPath);
            return configurator;
        }
    }
}