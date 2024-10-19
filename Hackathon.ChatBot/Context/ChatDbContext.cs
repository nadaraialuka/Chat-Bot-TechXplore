using System.Reflection;
using Hackathon.ChatBot.Auth;
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
            _ = modelBuilder.Entity<User>().HasData(GetUsers());
        }
        private User[] GetUsers()
        {
            SimplePasswordHasher passwordHasher = new();
            return
            [
                new() {
                    Address = "Tbilisi, Zgvis Ubani",
                    Email = "Lukanadaraia2001@gmail.com",
                    FirstName = "Luka",
                    LastName = "Nadaraia",
                    Id = 1,
                    PasswordHash = passwordHasher.HashPassword("luka1234"),
                    PhoneNumber = "599937315",
                    UserName = "nadaraialuka"
                }
            ];
        }
    }
}
