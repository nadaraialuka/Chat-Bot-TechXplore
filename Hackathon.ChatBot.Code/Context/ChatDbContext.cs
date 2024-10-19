using System.Reflection;
using Hackathon.ChatBot.Auth;
using Hackathon.ChatBot.Code.Entitites;
using Hackathon.ChatBot.Entitites;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.ChatBot.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Deposit> Deposits { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            _ = modelBuilder.Entity<User>().HasData(GetUsers());
            _ = modelBuilder.Entity<Account>().HasData(GetAccounts());
            _ = modelBuilder.Entity<Card>().HasData(GetCards());
            _ = modelBuilder.Entity<Deposit>().HasData(GetDeposits());
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

        private Account[] GetAccounts()
        {
            return
            [
                new() {
                    Id = 1,
                    Iban = "TBCGE89081239210321",
                    Ccy = "GEL",
                    Type = "მიმდინარე",
                    Subtype = "მიმდინარე",
                    CustomerId = 1,
                    OpenDate = new DateTime(2023, 1, 1)
                },
                new() {
                    Id = 2,
                    Iban = "TBCGE89081239210321",
                    Ccy = "USD",
                    Type = "მიმდინარე",
                    Subtype = "მიმდინარე",
                    CustomerId = 1,
                    OpenDate = new DateTime(2023, 1, 1)
                },
                new() {
                    Id = 3,
                    Iban = "TBCGE89081239210321",
                    Ccy = "EUR",
                    Type = "მიმდინარე",
                    Subtype = "მიმდინარე",
                    CustomerId = 1,
                    OpenDate = new DateTime(2023, 1, 1)
                }
            ];
        }

        private Card[] GetCards()
        {
            return
            [
                new(){
                    Id = 1,
                    Name = "Visa Platinum",
                    Type = "Visa",
                    CustomerId = 1,
                    Iban = "TBCGE89081239210333"
                },
                new(){
                    Id = 2,
                    Name = "MC World Elite",
                    Type = "MasterCard",
                    CustomerId = 1,
                    Iban = "TBCGE89081239210334"
                }
            ];
        }

        private Deposit[] GetDeposits()
        {
            return
            [
                new(){
                    Id = 1,
                    Name = "ჩემი მიზანი",
                    FriendlyName = "ახალი მობილური",
                    CustomerId = 1,
                    Iban = "TBCGE89081239210111",
                    Ccy = "GEL"
                },
                new(){
                    Id = 2,
                    Name = "ვადიანი ანაბარი",
                    FriendlyName = "ჩემი დანაზოგი",
                    CustomerId = 1,
                    Iban = "TBCGE89081239210222",
                    Ccy = "USD"
                }
            ];
        }
    }
}