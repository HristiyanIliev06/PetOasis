using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetOasis.Models
{
    [Table("User", Schema = "blg")]
    public class User :IdentityUser
    {
        [MaxLength(30)]
        [Required]
        public string FirstName { get; set; } = null!;
        [MaxLength(30)]
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        [Range(18, double.MaxValue, ErrorMessage = "Sorry! You are not mature enough to use our pet services!")]
        public int Age { get; set; }

       

        [ServiceStack.DataAnnotations.Unique]
        [MaxLength(100)]
        public override string? Email { get => base.Email; set => base.Email = value; }
        public List<Pet> Pets { get; set; }=new List<Pet>();

        public override string ToString()
        {
            return base.Email=null!;
        }
    }
}
