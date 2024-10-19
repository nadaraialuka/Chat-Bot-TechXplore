using Hackathon.ChatBot.Code.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.ChatBot.Code.Context
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(500);
            builder.Property(x => x.Type).HasMaxLength(500);
            builder.Property(x => x.CustomerId).IsRequired();
            builder.Property(x => x.Iban).HasMaxLength(500);
        }
    }
}
