using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetOasis.Models;

namespace PetOasis.Configuration
{
    public class ShelterConfiguration : IEntityTypeConfiguration<Shelter>
    {
        public void Configure(EntityTypeBuilder<Shelter> builder)
        {
            builder
            .HasKey(e => new { e.PetHotelId, e.PetId });
        }
    }
}
