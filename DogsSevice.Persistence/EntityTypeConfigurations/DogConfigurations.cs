using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DogsService.Domain;

namespace DogsService.Persistence.EntityTypeConfigurations
{
    public class DogConfigurations : IEntityTypeConfiguration<Dog>
    {
        public void Configure(EntityTypeBuilder<Dog> builder)
        {
            builder.HasKey(dog => dog.Id);
            builder.HasIndex(dog => dog.Id).IsUnique();
            builder.Property(dog => dog.Name).HasMaxLength(25);
        }
    }
}
