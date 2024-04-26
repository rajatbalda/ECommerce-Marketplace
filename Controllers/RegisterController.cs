using AmazonFresh.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmazonFresh.Controllers
{
    public class RegisterController : Controller
    {
        private readonly AmazonFreshContext _context;
        public RegisterController(AmazonFreshContext context)
        {
            _context = context;
        }
        public IActionResult Register() => View();
        [HttpPost]
        public IActionResult Register(Customer model)
        {
            model.CustomerCreation = DateTime.Now;
            if (ModelState.IsValid)
            {
                var account = new Customer
                {
                    Name = model.Name,
                    DateOfBirth = model.DateOfBirth,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    HomeAddress = model.HomeAddress,
                    CustomerCreation = model.CustomerCreation 
                };

                _context.Customers.Add(account);
                _context.SaveChanges();
                TempData["message"] = "Your registration is completed. Welcome to Amazon!";
                return RedirectToAction("Index", "Home");
            }
            TempData["message"] = "Please fix the error";
            return View("Register", model);
        }
        public IActionResult Login()=>View();
    }
}
