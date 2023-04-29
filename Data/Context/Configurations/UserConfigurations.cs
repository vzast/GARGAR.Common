using Data.Models.Public;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Context.Configurations
{
    internal class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));
            builder.Property(x => x.Firstname).HasMaxLength(50).IsUnicode(true).IsRequired(true);
            builder.Property(x => x.Lastname).HasMaxLength(50).IsUnicode(true).IsRequired(true);
        }
    }
}