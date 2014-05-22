using System.Web.Mvc;
using Cortoxa.Web.MVC.Components.Navigation.Model;

namespace Cortoxa.Web.MVC.Components.Navigation.Contracts
{
    public interface ISitemapManager<TNode> where TNode : SitemapNode
    {
        TNode GetSitemap();

        TNode Current { get; }
    }
}