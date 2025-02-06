using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetOasis.Models;
using System.Reflection.Emit;

namespace PetOasis.Configuration
{
    public class ShelterConfiguration : IEntityTypeConfiguration<Shelter>
    {
        public void Configure(EntityTypeBuilder<Shelter> builder)
        {
            builder
            .HasKey(e => new { e.PetHotelId, e.PetId });

            builder
            .HasOne(s => s.Pet)
            .WithMany(p => p.Shelters)
            .HasForeignKey(s => s.PetId);

            builder
                .HasOne(s => s.PetHotel)
                .WithMany(h => h.Shelters)
                .HasForeignKey(s => s.PetHotelId);
        }
    }
}
