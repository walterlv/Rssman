using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Toolkit.Parsers.Rss;

namespace Walterlv.Rssman.Services
{
    public class Rss
    {
        public async Task<IEnumerable<RssSchema>> FetchAsync(string feedUrl)
        {
            string feed = null;

            using (var client = new HttpClient())
            {
                try
                {
                    feed = await client.GetStringAsync(feedUrl);
                }
                catch
                {
                    // 这里暂不处理异常。
                }
            }

            if (feed != null)
            {
                var parser = new RssParser();
                var rss = parser.Parse(feed);
                return rss;
            }

            return Enumerable.Empty<RssSchema>();
        }
    }
}
