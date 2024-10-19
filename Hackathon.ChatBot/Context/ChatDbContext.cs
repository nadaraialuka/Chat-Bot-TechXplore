using Hackathon.ChatBot.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Hackathon.ChatBot.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users{ get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }
    }
}
