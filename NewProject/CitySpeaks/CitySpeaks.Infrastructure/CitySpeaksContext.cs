using CitySpeaks.Domain.Models;
using CitySpeaks.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CitySpeaks.Persistence
{
    public partial class CitySpeaksContext : DbContext
    {        
        public CitySpeaksContext(DbContextOptions<CitySpeaksContext> options)
            : base(options)
        {
        }
        public virtual DbSet<CustomPage> CustomPages { get; set; }
        public virtual DbSet<MainPage> MainPages { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<ProgramCategory> ProgramCategories { get; set; }
        public virtual DbSet<Program> Programs { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Image> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");            

            modelBuilder.ApplyConfiguration(new CustomPagesConfiguration());
            modelBuilder.ApplyConfiguration(new MainPagesConfiguration());
            modelBuilder.ApplyConfiguration(new NewsConfiguration());
            modelBuilder.ApplyConfiguration(new ProgramCategoriesConfiguration());
            modelBuilder.ApplyConfiguration(new ProgramsConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewsConfiguration());
            modelBuilder.ApplyConfiguration(new WorkersConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
        }
    }

    
}
