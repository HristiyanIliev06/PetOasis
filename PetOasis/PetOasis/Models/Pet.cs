using System.ComponentModel.DataAnnotations;

namespace PetOasis.Models
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; } = null!;
        [MaxLength(20)]
        [Required]
        public string Species { get; set; } = null!;
        [MaxLength(100)]
        [Required]
        public string Breed { get; set; } = null!;
        [Required]
        public uint Age { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "It's not possible for your pet to weigh less than 0 kg!")]
        public double Weight { get; set; }
        public IFormFile Image { get; set; } = null!;


    }
}
