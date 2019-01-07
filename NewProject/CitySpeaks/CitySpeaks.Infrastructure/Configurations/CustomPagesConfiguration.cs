using CitySpeaks.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CitySpeaks.Persistence.Configurations
{
    public class CustomPagesConfiguration : IEntityTypeConfiguration<CustomPage>
    {
        public void Configure(EntityTypeBuilder<CustomPage> builder)
        {
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Page).IsRequired();
        }
    }
}
