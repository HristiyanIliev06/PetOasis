using System.ComponentModel.DataAnnotations;

namespace PetOasis.Models
{
    public class PetHotel
    {

        [Key]
        public int Id { get; set; }

        [ServiceStack.DataAnnotations.Unique]
        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = null!;


        [Required]
        [MaxLength(30)]
        public string City {  get; set; } = null!;

        [Required]
        [MaxLength(30)]
        public string Street { get; set; } = null!;

        [Required]
        public uint Street_Number { get; set; }

        [Url]
        public string? Outside_View { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Description { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}

