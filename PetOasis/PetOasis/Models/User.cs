using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetOasis.Models
{
    [Table("User", Schema = "blg")]
    public class User :IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Age { get; set; }
        public IFormFile? AccountPicture { get; set; }

        public override string ToString()
        {
            return base.Email;
        }
    }
}
