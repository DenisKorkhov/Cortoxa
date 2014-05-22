using Cortoxa.Container;
using Cortoxa.Web.MVC.Components.Navigation.Contracts;
using Cortoxa.Web.MVC.Components.Navigation.Model;

namespace Cortoxa.Web.MVC.Components.Navigation
{
    public class SitemapManagerFactory : ISitemapManagerFactory
    {
        private readonly IToolContainer container;

        #region MyRegion
        public SitemapManagerFactory(IToolContainer container)
        {
            this.container = container;
        } 
        #endregion

        public ISitemapManager<T> Create<T>() where T : SitemapNode
        {
            return this.container.Resolver.Resolve(typeof (ISitemapManager<T>)) as ISitemapManager<T>;
        }
    }
}