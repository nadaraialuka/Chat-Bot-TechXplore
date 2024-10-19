using Hackathon.ChatBot.Code.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.ChatBot.Code.Context
{
    public class DepositConfiguration : IEntityTypeConfiguration<Deposit>
    {
        public void Configure(EntityTypeBuilder<Deposit> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(500);
            builder.Property(x =>x.FriendlyName).HasMaxLength(500);
            builder.Property(x =>x.Iban).HasMaxLength(500);
            builder.Property(x =>x.Ccy).HasMaxLength(500);
            builder.Property(x =>x.OpenDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.CustomerId).IsRequired();
        }
    }
}
