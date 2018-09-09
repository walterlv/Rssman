using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Walterlv.WebApi.Rssman.Models;

namespace Walterlv.WebApi.Rssman.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RssController : ControllerBase
    {
        private readonly RssFeedContext _context;

        public RssController(RssFeedContext context)
        {
            _context = context;

            if (!_context.RssFeedItems.Any())
            {
                _context.RssFeedItems.Add(new RssFeedItem
                {
                    Name = "walterlv",
                    SiteUrl = "https://walterlv.com/",
                    FeedUrl = "https://walterlv.com/feed.xml",
                });
                _context.RssFeedItems.Add(new RssFeedItem
                {
                    Name = "lindexi",
                    SiteUrl = "https://lindexi.gitee.io/",
                    FeedUrl = "https://lindexi.gitee.io/lindexi/feed.xml",
                });
                _context.SaveChanges();
            }
        }

        // GET: api/Rss
        [HttpGet]
        public ActionResult<List<RssFeedItem>> Get()
        {
            return _context.RssFeedItems.ToList();
        }

        // GET: api/Rss/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<RssFeedItem> Get(long id)
        {
            var item = _context.RssFeedItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // POST: api/Rss
        [HttpPost]
        public IActionResult Post([FromBody] RssFeedItem item)
        {
            _context.RssFeedItems.Add(item);
            _context.SaveChanges();
            return CreatedAtRoute("Get", new { id = item.Id }, item);
        }

        // PUT: api/Rss/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] RssFeedItem item)
        {
            var feed = _context.RssFeedItems.Find(id);
            if (feed == null)
            {
                return NotFound();
            }

            feed.Name = item.Name;
            feed.FeedUrl = item.FeedUrl;
            feed.SiteUrl = item.SiteUrl;

            _context.RssFeedItems.Update(feed);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var feed = _context.RssFeedItems.Find(id);
            if (feed == null)
            {
                return NotFound();
            }

            _context.RssFeedItems.Remove(feed);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
