using AmazonFresh.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmazonFresh.Controllers
{
    public class ValidationController : Controller
    {
        private AmazonFreshContext context;
        public ValidationController(AmazonFreshContext ctx) => context = ctx;

        public JsonResult CheckEmail(string email)
        {
            string msg = Check.EmailExists(context, email);
            if (string.IsNullOrEmpty(msg))
            {
                TempData["okEmail"] = true;
                return Json(true);
            }
            else return Json(msg);
        }
    }
}
