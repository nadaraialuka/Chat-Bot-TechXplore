using Hackathon.ChatBot.Code.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.ChatBot.Code.Context
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(a => a.Iban).HasMaxLength(500);
            builder.Property(a => a.Ccy).HasMaxLength(500);
            builder.Property(a => a.Type).HasMaxLength(500);
            builder.Property(a => a.Subtype).HasMaxLength(500);
            builder.Property(a => a.CustomerId).IsRequired();
            builder.Property(a => a.OpenDate).HasDefaultValueSql("GETDATE()");
        }
    }
}
