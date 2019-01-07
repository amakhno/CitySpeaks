using CitySpeaks.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CitySpeaks.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.UserName);
            builder.Property(e => e.Password).IsRequired();
            builder.Property(e => e.RoleId).IsRequired();
            builder.HasOne(x => x.Role);
        }
    }
}
