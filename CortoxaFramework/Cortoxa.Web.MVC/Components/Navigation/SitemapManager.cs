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

        protected TNode BuildSitemap()
        {
            return reader.LoadMap();
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