using Cortoxa.Web.MVC.Components.Navigation.Model;

namespace Cortoxa.Web.MVC.Components.Navigation.Contracts
{
    public interface ISitemapReader<TNode> where TNode : SitemapNode
    {
        void Generate(TNode node);

        TNode LoadMap();

        TNode LoadMap(string source);
    }
}