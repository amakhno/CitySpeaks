using CitySpeaks.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CitySpeaks.Persistence.Configurations
{
    public class MainPagesConfiguration : IEntityTypeConfiguration<MainPage>
    {
        public void Configure(EntityTypeBuilder<MainPage> builder)
        {
            builder.Property(e => e.Description).IsRequired();
            builder.Property(e => e.Subtitle).IsRequired();
            builder.Property(e => e.Title).IsRequired();
        }
    }
}
