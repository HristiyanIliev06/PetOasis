namespace PetOasis.Models
{
    public class PetHotel
    {
        public string Name { get; set; } = null!;

        public string City {  get; set; } = null!;
        public string Street { get; set; } = null!;

        public string Street_Number { get; set; } = null!;

        public IFormFile Outside_View { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}

