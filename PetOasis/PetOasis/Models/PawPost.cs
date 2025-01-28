using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetOasis.Models
{
    [Table("PawPost", Schema = "blg")]
    public class PawPost
    {  
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public IFormFile? Image { get; set; }
        public DateTime? When_uploaded {  get; set; }
        public string? Additional_mentions {  get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
