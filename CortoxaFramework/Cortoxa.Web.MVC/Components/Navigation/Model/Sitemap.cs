using System;
using System.Xml.Serialization;

namespace Cortoxa.Web.MVC.Components.Navigation.Model
{
    [Serializable]
    [XmlRoot("sitemap")]
    [XmlType("sitemap")]
    public class Sitemap<TNode> where TNode : SitemapNode
    {
        [XmlElement(ElementName = "root")]
        public SitemapNode Root { get; set; }
    }
}