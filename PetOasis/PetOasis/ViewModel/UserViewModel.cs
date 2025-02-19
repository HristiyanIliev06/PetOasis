using PetOasis.Models;
using System.ComponentModel.DataAnnotations;

namespace PetOasis.ViewModel
{
    public class UserViewModel
    {
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public int Age { get; set; }

        public  string? Email { get; set; }

        public IFormFile? AccountPicture { get; set; }
       
    }
}
