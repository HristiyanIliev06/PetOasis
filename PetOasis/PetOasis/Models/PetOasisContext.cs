using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetOasis.Configuration;
using System.Reflection;

namespace PetOasis.Models
{
    public class PetOasisContext : IdentityDbContext<User>
    {
        public PetOasisContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ShelterConfiguration());
            builder.ApplyConfiguration(new PawPostConfiguration());
            base.OnModelCreating(builder);
        }
        public DbSet<PawPost> PawPosts { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetHotel> PetHotels { get; set; }
        public DbSet<Shelter> Shelters { get; set; }
    }
}
