using Hackathon.ChatBot.Hubs;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.ChatBot.Context
{
    public class ChatDbContext : DbContext
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options) { }

        public DbSet<ChatMessage> ChatMessages { get; set; }
    }
}
