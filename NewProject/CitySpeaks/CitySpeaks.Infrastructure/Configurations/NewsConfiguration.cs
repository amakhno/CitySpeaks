using CitySpeaks.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CitySpeaks.Persistence.Configurations
{
    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.Property(e => e.Date).HasColumnType("datetime");
            builder.Property(e => e.FullDescription).IsRequired();
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.ShortDescription).IsRequired();
        }
    }
}
