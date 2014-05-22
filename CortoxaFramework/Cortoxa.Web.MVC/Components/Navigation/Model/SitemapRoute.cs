using System;
using System.Xml.Serialization;

namespace Cortoxa.Web.MVC.Components.Navigation.Model
{
    [Serializable]
    public class SitemapRoute
    {
        #region Constructors
        public SitemapRoute()
        {
        }

        public SitemapRoute(string action)
        {
            Action = action;
        }

        public SitemapRoute(string controller, string action)
        {
            Controller = controller;
            Action = action;
        }

        public SitemapRoute(string controller, string action, string @params)
        {
            Controller = controller;
            Action = action;
            Params = @params;
        } 
        #endregion

        [XmlAttribute("controller")]
        public string Controller { get; set; }

        [XmlAttribute("action")]
        public string Action { get; set; }

        [XmlAttribute("params")]
        public string Params { get; set; }
    }
}