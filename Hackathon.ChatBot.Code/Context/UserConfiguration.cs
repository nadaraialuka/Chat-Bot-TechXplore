using Hackathon.ChatBot.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.ChatBot.Context
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("AppUsers", "User");
            builder.HasKey(t => t.Id);
            builder.Property(x => x.Address).IsUnicode(true).IsRequired(true);
            builder.Property(x => x.PhoneNumber).IsUnicode(true).IsRequired(true);
            builder.Property(x => x.FirstName).IsUnicode(true).IsRequired(true);
            builder.Property(x => x.UserName).IsUnicode(true).IsRequired(true);
            builder.Property(x => x.LastName).IsUnicode(true).IsRequired(true);
            builder.Property(x => x.PasswordHash).IsUnicode(true).IsRequired(true);
        }
    }
}
