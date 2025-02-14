using Azure;
using PetOasis.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetOasis.Data.Entities
{
    [Table("Shelters", Schema = "blg")]
    public class Shelter
    {
        public int PetHotelId { get; set; }

        public PetHotel PetHotel { get; set; } = null!;
        public int PetId { get; set; }

        public Pet Pet { get; set; } = null!;
    }
}
