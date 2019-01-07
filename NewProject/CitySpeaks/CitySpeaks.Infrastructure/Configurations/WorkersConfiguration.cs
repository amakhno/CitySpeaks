using CitySpeaks.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CitySpeaks.Persistence.Configurations
{
    public class WorkersConfiguration : IEntityTypeConfiguration<Workers>
    {
        public void Configure(EntityTypeBuilder<Workers> builder)
        {
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.ShortDescription).IsRequired();
        }
    }
}
