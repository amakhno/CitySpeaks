using CitySpeaks.Domain.Models;
using CitySpeaks.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CitySpeaks.Infrastructure
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
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<ProgramCategories> ProgramCategories { get; set; }
        public virtual DbSet<Programs> Programs { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<Workers> Workers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {                
                optionsBuilder.UseSqlServer("Server=.;Database=CitySpeaks;Trusted_Connection=True;");
            }
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
        }
    }

    
}
