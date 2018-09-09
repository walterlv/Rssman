using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Walterlv.WebApi.Rssman.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RssController : ControllerBase
    {
        // GET: api/Rss
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "https://walterlv.com/feed.xml", "https://lindexi.gitee.io/lindexi/feed.xml" };
        }

        // GET: api/Rss/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Rss
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Rss/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
