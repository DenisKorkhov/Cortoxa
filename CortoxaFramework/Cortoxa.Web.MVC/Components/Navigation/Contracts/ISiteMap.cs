using System.Web;

namespace Cortoxa.Web.MVC.Components.Navigation.Contracts
{
    public interface ISiteMap<TNode> where TNode : SiteMapNode
    {
        TNode Root { get; set; } 
    }
}