using Azure;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetOasis.Models
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
