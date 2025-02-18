using Microsoft.AspNetCore.Identity;
using PetOasis.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetOasis.Data.Entities
{
    [Table("User", Schema = "blg")]
    public class User : IdentityUser
    {
        [MaxLength(30)]
        public string? FirstName { get; set; }
        [MaxLength(30)]
        public string? LastName { get; set; }
        [Range(18, double.MaxValue, ErrorMessage = "Sorry! You are not mature enough to use our pet services!")]
        public int Age { get; set; }

        public string? AccountPicture { get; set; }

        [ServiceStack.DataAnnotations.Unique]
        [MaxLength(100)]
        public override string? Email { get => base.Email; set => base.Email = value; }
        public List<Pet> Pets { get; set; } = new List<Pet>();

        public override string ToString()
        {
            return base.Email = null!;
        }
    }
}
