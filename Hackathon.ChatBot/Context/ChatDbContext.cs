using System.Reflection;
using Hackathon.ChatBot.Entitites;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.ChatBot.Context
{
    public class AppDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<User>().HasData(GetUsers());
        }
        private User[] GetUsers() 
        {
            return new User[]
            {
                new User{ 
                    Address = "Tbilisi, Zgvis Ubani", 
                    Email = "Lukanadaraia2001@gmail.com", 
                    FirstName = "Luka", 
                    LastName = "Nadaraia", 
                    Id = Guid.NewGuid(), 
                    PasswordHash = "XVD/vyDIwqyZNkUnBVQ52gaoNKTME0QFJXWKijC92GM=",
                    PhoneNumber = "599937315",
                    UserName = "nadaraialuka"
                }
            };
        }
    }
}
