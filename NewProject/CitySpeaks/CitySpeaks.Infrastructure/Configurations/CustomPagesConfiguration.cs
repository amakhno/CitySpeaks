using CitySpeaks.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CitySpeaks.Persistence.Configurations
{
    public class CustomPagesConfiguration : IEntityTypeConfiguration<CustomPages>
    {
        public void Configure(EntityTypeBuilder<CustomPages> builder)
        {
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Page).IsRequired();
        }
    }
}
