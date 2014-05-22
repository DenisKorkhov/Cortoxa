using System.IO;
using Cortoxa.Common;
using Cortoxa.Web.MVC.Components.Navigation.Contracts;
using Cortoxa.Web.MVC.Components.Navigation.Model;

namespace Cortoxa.Web.MVC.Components.Navigation
{
    public class SitemapFileReader<TNode> : ISitemapReader<TNode> where TNode : SitemapNode
    {
        #region Fields

        private readonly string path; 

        #endregion

        #region Constructor

        public SitemapFileReader(string path)
        {
            this.path = path;
        } 

        #endregion

        #region ISitemapReader implementation

        public void Generate(TNode node)
        {
            #if DEBUG
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using (var file = new FileStream(path, FileMode.Create))
            {
                node.Serialize(file);
            }

            #endif
        }

        public TNode LoadMap()
        {
            return LoadMap(path);
        }

        public TNode LoadMap(string source)
        {
            if (!File.Exists(path))
            {
                throw new FileLoadException("File not exist", path);
            }

            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                return fileStream.Deserialize<TNode>();
            }
        }

        #endregion
    }
}