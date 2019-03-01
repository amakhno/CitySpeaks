using CitySpeaks.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CitySpeaks.Persistence.Configurations
{
    public class ReviewsConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.ShortDescription).IsRequired();
            builder.HasOne(x => x.Image).WithOne().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
