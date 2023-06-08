using Microsoft.EntityFrameworkCore;
using DogsService.Application.Interfaces;
using DogsService.Domain;
using DogsService.Persistence.EntityTypeConfigurations;

namespace DogsService.Persistence
{
    public class DogsDbContext : DbContext, IDogsDbContext
    {
        public DbSet<Dog> Dogs { get; set; }

        public DogsDbContext(DbContextOptions<DogsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DogConfigurations());
            base.OnModelCreating(builder);
        }
    }
}

    
