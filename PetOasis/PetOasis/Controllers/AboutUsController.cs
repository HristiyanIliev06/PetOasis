using Microsoft.AspNetCore.Mvc;

namespace PetOasis.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View("AboutUs");
        }
    }
}
