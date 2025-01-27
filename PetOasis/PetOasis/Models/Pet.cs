namespace PetOasis.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Species { get; set; } = null!;
        public string Breed { get; set; } = null!;
        public int Age { get; set; }
        public int Weight { get; set; }
        public IFormFile Image { get; set; } = null!;


    }
}
