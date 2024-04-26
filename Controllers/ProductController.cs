using Microsoft.AspNetCore.Mvc;

namespace AmazonFresh.Controllers
{
    public class ProductController : Controller
    {
        [Route("ProductCategory")]
        public IActionResult Category()
        {
            return Content("Regular => Product Controller - Category Action");
        }
        [Route("Product/{id?}")]
        public IActionResult Index(string id = "All")
        {   Object objId = (Object)id;
            return Content("Regular => Product => Index => Value = " + objId);
        }
    }
}
