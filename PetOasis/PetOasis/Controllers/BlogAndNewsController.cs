using Microsoft.AspNetCore.Mvc;

namespace PetOasis.Controllers
{
    public class BlogAndNewsController : Controller
    {
        public ActionResult Index()
        {
            return View("Blog&News");
        }
    }

}
