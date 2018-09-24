using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using Walterlv.Rssman.Models;

namespace Walterlv.Rssman.Services
{
    public static class Opml
    {
        [Pure]
        public static async Task<RssOpml> ParseAsync(Stream stream)
        {
            var document = await XDocument.LoadAsync(stream, LoadOptions.None, CancellationToken.None);
            var root = document.XPathSelectElement("opml");
            var opml = new RssOpml();
            opml.Deserialize(root);
            return opml;
        }

        [Pure]
        public static IEnumerable<RssOutline> GetOutlines(this RssOpml opml)
        {
            return Enumerate(opml.Children);

            IEnumerable<RssOutline> Enumerate(IEnumerable<RssOutline> source)
            {
                foreach (var child in source)
                {
                    if (child.HasChildren)
                    {
                        foreach (var grandChild in Enumerate(child.Children))
                        {
                            yield return grandChild;
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(child.XmlUrl))
                    {
                        yield return child;
                    }
                }
            }
        }
    }
}
