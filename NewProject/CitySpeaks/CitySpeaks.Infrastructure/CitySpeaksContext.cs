using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CitySpeaks.Domain.Models
{
    public partial class CitySpeaksContext : DbContext
    {
        public CitySpeaksContext()
        {
        }

        public CitySpeaksContext(DbContextOptions<CitySpeaksContext> options)
            : base(options)
        {
        }
        public virtual DbSet<CustomPages> CustomPages { get; set; }
        public virtual DbSet<MainPages> MainPages { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<ProgramCategories> ProgramCategories { get; set; }
        public virtual DbSet<Programs> Programs { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<Workers> Workers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=CitySpeaks;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");            

            modelBuilder.Entity<CustomPages>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Page).IsRequired();
            });

            modelBuilder.Entity<MainPages>(entity =>
            {
                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Subtitle).IsRequired();

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.FullDescription).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.ShortDescription).IsRequired();
            });

            modelBuilder.Entity<ProgramCategories>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK_dbo.ProgramCategories");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Programs>(entity =>
            {
                entity.HasKey(e => e.ProgramId)
                    .HasName("PK_dbo.Programs");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("IX_CategoryId");

                entity.Property(e => e.FullDescription).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.ShortDescription).IsRequired();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Programs)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_dbo.Programs_dbo.ProgramCategories_CategoryId");
            });

            modelBuilder.Entity<Reviews>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.ShortDescription).IsRequired();
            });

            modelBuilder.Entity<Workers>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.ShortDescription).IsRequired();
            });
        }
    }
}
