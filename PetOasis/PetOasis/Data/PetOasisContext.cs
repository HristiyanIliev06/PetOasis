using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetOasis.Data.Entities;

namespace PetOasis.Data
{
    public class PetOasisContext : IdentityDbContext<User>
    {
        public PetOasisContext(DbContextOptions<PetOasisContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Shelter>()
            .HasKey(e => new { e.PetHotelId, e.PetId });

            builder.Entity<Shelter>()
            .HasOne(s => s.Pet)
            .WithMany(p => p.Shelters)
            .HasForeignKey(s => s.PetId);

            builder.Entity<Shelter>()
                .HasOne(s => s.PetHotel)
                .WithMany(h => h.Shelters)
                .HasForeignKey(s => s.PetHotelId);

            builder.Entity<PawPost>()
               .Property(e => e.When_uploaded)
               .ValueGeneratedOnAddOrUpdate();

            builder.Entity<Pet>()
                .HasOne(p => p.Owner)
                .WithMany(u => u.Pets)
                .HasForeignKey(p => p.OwnerId);



        }
        public DbSet<PawPost> PawPosts { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetHotel> PetHotels { get; set; }
        public DbSet<Shelter> Shelters { get; set; }
    }
}
