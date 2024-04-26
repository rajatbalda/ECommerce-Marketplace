using Microsoft.AspNetCore.Mvc;

namespace AmazonFresh.Areas.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        [Route("[area]/[controller]/")]
        public IActionResult Index()
        {
            return View();
        }
        //[Route("[area]/categories/")]
        [Route("[area]/[controller]/categories/")]

        public IActionResult Category()
        {
            return Content("Admin -> Home -> Category   Area Admin Route");
        }
    }
}
