using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetOasis.Data;
using PetOasis.Data.Entities;
using PetOasis.Models;
using PetOasis.ViewModel;

namespace PetOasis.Controllers
{
    public class HomeController : Controller
    {
        private readonly PetOasisContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(PetOasisContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //var viewModel = new ViewModels
            //{
            //    PetHotels = _context.PetHotels.ToList(),
            //    PawPosts = _context.PawPosts.ToList()
            //};

            //return View(viewModel);

            try
            {
                var viewModel = new ViewModels
                {
                    PetHotels = _context.PetHotels.ToList(),
                    PawPosts = _context.PawPosts.ToList()
                };

                _logger.LogInformation("Successfully retrieved data for Home Index view.");
                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching data for Home Index.");
                return View("Error"); // Redirect to an error page if needed
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
