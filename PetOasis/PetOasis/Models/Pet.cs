using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetOasis.Models
{
    public enum Species
    {
        dog,
        cat,
        bird
    }
    [Table("Pet", Schema ="blg")]
    public class Pet
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        [Display(Name = "Name: ", Prompt = "My pet's name is...")]
        public string Name { get; set; } = null!;

        [MaxLength(20)]
        [Required]
        [Display(Name = "Species: ", Prompt = "My pet's species is...")]
        public Species Species { get; set; } 

        [MaxLength(100)]
        [Required]
        [Display(Name = "Breed (optional): ", Prompt = "My pet's breed is...")]
        public string? Breed { get; set; }

        [Required]
        [Display(Name = "Age: ", Prompt = "My pet's age is...")]
        public uint Age { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "It's not possible for your pet to weigh less than 0 kg!")]
        [Display(Name = "Weight (kg): ", Prompt = "My pet weighs...")]
        public double Weight { get; set; }

        public IFormFile? Image { get; set; }
        public User Owner { get; set; } = null!;
        public string OwnerId { get; set; } = null!;

        public List<Shelter> Shelters { get; set; } = new List<Shelter>();


    }
}
