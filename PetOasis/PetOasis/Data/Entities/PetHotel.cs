using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetOasis.Data.Entities
{
    [Table("PetHotel", Schema = "blg")]
    public class PetHotel
    {

        [Key]
        public int Id { get; set; }

        [ServiceStack.DataAnnotations.Unique]
        [Required]
        public string Name { get; set; } = null!;


        [Required]
        public string City { get; set; } = null!;

        [Required]
        public string Street { get; set; } = null!;

        [Required]
        public uint Street_Number { get; set; }

        [Url]
        public string? Outside_View { get; set; }

        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Description { get; set; }
        public List<Shelter> Shelters { get; set; } = new List<Shelter>();

        public override string ToString()
        {
            return Name;
        }
    }
}

