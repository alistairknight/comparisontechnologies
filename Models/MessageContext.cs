using Microsoft.EntityFrameworkCore;

namespace MessageApi.Models
{
    public class MessageContext : DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options) : base(options)
        {
        }

        public DbSet<MessageItem> Messages { get; set; }
        public DbSet<MessageUser> Users { get; set; }
    }
}