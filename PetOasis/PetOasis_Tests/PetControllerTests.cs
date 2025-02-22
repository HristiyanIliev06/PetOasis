using Microsoft.AspNetCore.Mvc;
using Moq;
using Microsoft.EntityFrameworkCore;
using PetOasis.Controllers;
using PetOasis.Data;
using PetOasis.Data.Entities;
using Xunit;

namespace PetOasis_Tests
{
    public class PetsControllerTests
    {
        private readonly PetOasisContext _context;
        private readonly PetsController _controller;
        private readonly List<Pet> _pets;

        public PetsControllerTests()
        {
            var options = new DbContextOptionsBuilder<PetOasisContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new PetOasisContext(options);
            _controller = new PetsController(_context);

            // Примерни данни
            _pets = new List<Pet>
            {
                new Pet
                {
                    Id = 1,
                    Name = "Dora",
                    Species = Species.dog,
                    Breed = "Husky",
                    Age = 2,
                    Image = "dora.jpg",
                    Weight = 30.5,
                    OwnerId = "1",
                    Owner = new User { Id = "1", UserName = "Erhan Nebi" }
                },
                new Pet
                {
                    Id = 2,
                    Name = "Max",
                    Species = Species.cat,
                    Breed = "Persian",
                    Age = 3,
                    Image = "max.jpg",
                    Weight = 4.2,
                    OwnerId = "2",
                    Owner = new User { Id = "2", UserName = "Ivan Ivanov" }
                }
            };

            _context.Pets.AddRange(_pets);
            _context.SaveChanges();
        }

        [Fact]
        public void Index_ReturnsViewResult_WithListOfPets()
        {
            // Act
            var result = _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Pet>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void Details_ReturnsViewResult_WithPet()
        {
            // Arrange
            var petId = _pets[0].Id;

            // Act
            var result = _controller.Details(petId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Pet>(viewResult.ViewData.Model);
            Assert.Equal(petId, model.Id);
        }

        [Fact]
        public void Details_ReturnsNotFound_WhenPetNotFound()
        {
            // Act
            var result = _controller.Details(999); // Несъществуващ ID

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Create_ReturnsViewResult()
        {
            // Act
            var result = _controller.Create();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Create_Post_ReturnsRedirectToActionResult_WhenModelStateIsValid()
        {
            // Arrange
            var pet = new Pet
            {
                Name = "Bella",
                Species = Species.bird,
                Breed = "Parrot",
                Age = 1,
                Weight = 0.5,
                OwnerId = "3",
                Owner = new User { Id = "3", UserName = "John Doe" }
            };

            // Act
            var result = _controller.Create(pet);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public void Create_Post_ReturnsViewResult_WhenModelStateIsInvalid()
        {
            // Arrange
            _controller.ModelState.AddModelError("Name", "Required");

            var pet = new Pet
            {
                Species = Species.dog,
                Breed = "Bulldog",
                Age = 4,
                Weight = 20.5,
                OwnerId = "4"
            };

            // Act
            var result = _controller.Create(pet);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Pet>(viewResult.ViewData.Model);

            Assert.Equal(pet, model);
        }

        [Fact]
        public void Edit_Get_ReturnsViewResult_WithPet()
        {
            // Arrange
            var petId = _pets[0].Id;

            // Act
            var result = _controller.Edit(petId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<Pet>(viewResult.ViewData.Model);

            Assert.Equal(petId, model.Id);
        }

        [Fact]
        public void Edit_Get_ReturnsNotFound_WhenPetNotFound()
        {
            // Act
            var result = _controller.Edit(999); // Несъществуващ ID

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Delete_Post_ReturnsRedirectToActionResult_WhenPetIsDeleted()
        {
            // Arrange
            var petIdToDelete = _pets[0].Id;

            // Act
            var result = _controller.Delete(petIdToDelete);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);

            Assert.Equal("Index", redirectToActionResult.ActionName);

            Assert.DoesNotContain(_context.Pets, p => p.Id == petIdToDelete); // Проверяваме дали е изтрито
        }

        [Fact]
        public void Delete_Post_ReturnsNotFound_WhenPetNotFound()
        {
            // Act
            var result = _controller.Delete(999); // Несъществуващ ID

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
