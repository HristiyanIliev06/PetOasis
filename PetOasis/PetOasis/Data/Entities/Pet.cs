using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetOasis.Data.Entities
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

        [Required]
        [Display(Name = "Name: ", Prompt = "My pet's name is...")]
        public string Name { get; set; } = null!;

        [Required]
        [Display(Name = "Species: ", Prompt = "My pet's species is...")]
        public Species Species { get; set; } 

        [Required]
        [Display(Name = "Breed (optional): ", Prompt = "My pet's breed is...")]
        public string? Breed { get; set; }

        [Required]
        [Display(Name = "Age: ", Prompt = "My pet's age is...")]
        public uint Age { get; set; }

        public string? Image { get; set; }

        [Required]
        [Display(Name = "Weight (kg): ", Prompt = "My pet weighs...")]
        public double Weight { get; set; }
        public User Owner { get; set; } = null!;
        public string OwnerId { get; set; } = null!;

        public List<Shelter> Shelters { get; set; } = new List<Shelter>();


    }
}
