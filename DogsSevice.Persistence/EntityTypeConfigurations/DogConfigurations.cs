using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
