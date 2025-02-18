using Microsoft.AspNetCore.Identity;
using PetOasis.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetOasis.Data.Entities
{
    [Table("User", Schema = "blg")]
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public string? AccountPicture { get; set; }

        [ServiceStack.DataAnnotations.Unique]
        public override string? Email { get => base.Email; set => base.Email = value; }
        public List<Pet> Pets { get; set; } = new List<Pet>();

        public override string ToString()
        {
            return base.Email = null!;
        }
    }
}
