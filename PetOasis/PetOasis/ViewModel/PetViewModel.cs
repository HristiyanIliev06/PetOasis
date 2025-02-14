using Microsoft.AspNetCore.Http;
using PetOasis.Data.Entities;
using PetOasis.Models;

public class PetViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public Species Species { get; set; }
    public string? Breed { get; set; }
    public uint Age { get; set; }
    public double Weight { get; set; }

    // Свойство за качване на изображение
    public IFormFile? ImageFile { get; set; }
}
