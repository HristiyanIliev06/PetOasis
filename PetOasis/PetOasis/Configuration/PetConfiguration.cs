using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetOasis.Models;

namespace PetOasis.Configuration
{
    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder
                .HasOne(p => p.Owner) 
                .WithMany(u => u.Pets) 
                .HasForeignKey(p => p.OwnerId);

        }
    }
}
