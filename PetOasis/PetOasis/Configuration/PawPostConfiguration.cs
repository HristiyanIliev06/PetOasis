using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetOasis.Models;

namespace PetOasis.Configuration
{
    public class PawPostConfiguration : IEntityTypeConfiguration<PawPost>
    {
        public void Configure(EntityTypeBuilder<PawPost> builder)
        {
            builder
                .Property(e => e.Additional_mentions)
                .ValueGeneratedOnAddOrUpdate();
        }
    }

}


