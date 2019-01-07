using CitySpeaks.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CitySpeaks.Persistence.Configurations
{
    public class ProgramsConfiguration : IEntityTypeConfiguration<Programs>
    {
        public void Configure(EntityTypeBuilder<Programs> builder)
        {
            builder.HasKey(e => e.ProgramId)
                    .HasName("PK_dbo.Programs");
            builder.HasIndex(e => e.CategoryId)
                .HasName("IX_CategoryId");
            builder.Property(e => e.FullDescription).IsRequired();
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.ShortDescription).IsRequired();
            builder.HasOne(d => d.Category)
                .WithMany(p => p.Programs)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_dbo.Programs_dbo.ProgramCategories_CategoryId");
        }
    }
}
