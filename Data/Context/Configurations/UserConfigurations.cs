using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models.Public;

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
