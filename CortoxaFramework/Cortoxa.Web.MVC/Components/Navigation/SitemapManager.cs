using System.Net;
using System.Web;
using System.Web.Mvc;
using Cortoxa.Web.MVC.Components.Navigation.Contracts;
using Cortoxa.Web.MVC.Components.Navigation.Model;

namespace Cortoxa.Web.MVC.Components.Navigation
{
    public class SitemapManager<TNode> : ISitemapManager<TNode> where TNode : SitemapNode
    {
        #region Fields
        private readonly ISitemapReader<TNode> reader;
        private TNode root = null;
        #endregion

        public SitemapManager(ISitemapReader<TNode> reader)
        {
            this.reader = reader;
        }


        protected void NormalizeFields(SitemapNode node, SitemapRoute route = null, string[] roles = null)
        {
            if (route != null)
            {
                if (node.Route == null)
                {
                    node.Route = route;
                }
                else if (string.IsNullOrEmpty(node.Route.Controller))
                {
                    node.Route.Controller = route.Controller;
                }
            }

            if (node.Roles == null)
            {
                node.Roles = roles;
            }


            foreach (var child in node.Children)
            {
                NormalizeFields(child, node.Route, node.Roles);
            }
        }

        protected TNode BuildSitemap()
        {
            TNode result = reader.LoadMap();
            NormalizeFields(result);
            return result;
        }

        public TNode FindNode(string controller, string action)
        {
            return null;
        }

        public TNode GetSitemap()
        {
            return root ?? (root = BuildSitemap());
        }

        public TNode Current
        {
            get
            {
//                HttpContext.Current
                return null;
            }
        }
    }
}