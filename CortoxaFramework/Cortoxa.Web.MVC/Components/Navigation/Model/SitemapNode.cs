using System.Web;
using System.Xml.Serialization;
using Cortoxa.Web.MVC.Components.Navigation.Contracts;

namespace Cortoxa.Web.MVC.Components.Navigation.Model
{
    public class SitemapNode
    {
        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlAttribute("key")]
        public string Key { get; set; }

//        [XmlAttribute("url")]
//        public string RawUrl { get; set; }

        [XmlAttribute("clickable")]
        public bool Clickable { get; set; }

        [XmlAttribute("visible")]
        public bool Visible { get; set; }

        [XmlElement(ElementName = "route")]
        public SitemapRoute Route { get; set; }

        [XmlArray(ElementName = "roles")]
        [XmlArrayItem(ElementName = "role")]
        public string[] Roles { get; set; }

        [XmlArray(ElementName = "nodes")]
        [XmlArrayItem(ElementName = "node")]
        public SitemapNode[] Children { get; set; } 
    }
}