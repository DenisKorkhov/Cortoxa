using Cortoxa.Web.MVC.Components.Navigation.Model;

namespace Cortoxa.Web.MVC.Components.Navigation.Contracts
{
    public interface ISitemapManagerFactory
    {
        ISitemapManager<T> Create<T>() where T : SitemapNode;
    }
}