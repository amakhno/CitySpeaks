using CitySpeaks.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CitySpeaks.Persistence.Configurations
{
    public class WorkersConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.ShortDescription).IsRequired();
            builder.HasOne(e => e.BigImage).WithOne().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.SmallImage).WithOne().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
