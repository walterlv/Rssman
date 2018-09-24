using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using Walterlv.Rssman.Models;

namespace Walterlv.Rssman.Services
{
    public class Opml
    {
        public static async Task<RssOpml> ParseAsync(Stream stream)
        {
            var document = await XDocument.LoadAsync(stream, LoadOptions.None, CancellationToken.None);
            var root = document.XPathSelectElement("opml");
            var opml = new RssOpml();
            opml.Deserialize(root);
            return opml;
        }
    }
}
