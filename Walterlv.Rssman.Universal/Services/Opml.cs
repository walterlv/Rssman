using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Walterlv.Rssman.Models;

namespace Walterlv.Rssman.Services
{
    public class Opml
    {
        private static List<RssPage> Parse(Stream stream)
        {
            var document = XDocument.Load(stream);

            document.
        }
    }
}
