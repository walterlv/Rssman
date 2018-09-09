using Microsoft.EntityFrameworkCore;

namespace Walterlv.WebApi.Rssman.Models
{
    public class RssFeedContext : DbContext
    {
        public RssFeedContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<RssFeedItem> RssFeedItems { get; set; }
    }
}
