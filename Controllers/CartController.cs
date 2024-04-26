using AmazonFresh.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmazonFresh.Controllers
{
    public class CartController : Controller
    {
        private readonly AmazonFreshContext _context;

        public CartController(AmazonFreshContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var session = new AmazonFreshSession(HttpContext.Session);
            var model = new AmazonFreshViewModel
            {
                ActiveVendor = session.GetActiveConf(),
                ActiveWarehouse = session.GetActiveDiv(),
                Products = session.GetMyProducts()
            };

            return View(model);
        }
        [HttpPost]
        public RedirectToActionResult Add(Product product)
        {
            product = _context.Products
                 .Include(t => t.Vendor)
                 .Include(t => t.Warehouse)
                 .Where(t => t.ProductID == product.ProductID)
                 .FirstOrDefault() ?? new Product();
            var session = new AmazonFreshSession(HttpContext.Session);
            var cookies = new AmazonFreshCookies(Response.Cookies);
            product.TotalQty = 1;
            var products = session.GetMyProducts();
            products.Add(product);
            session.SetMyProducts(products);
            cookies.SetMyTeamIds(products);
            TempData["message"] = $"{product.Name} added to your cart";
            return RedirectToAction("Index", "Home",
                new
                {
                    ActiveConf = session.GetActiveConf(),
                    ActiveDiv = session.GetActiveDiv()
                });
        }
        [HttpPost]
        public IActionResult Checkout()
        {
            var session = new AmazonFreshSession(HttpContext.Session);
            var products = session.GetMyProducts();
            foreach (var item in products)
            {
                var product = _context.Products.FirstOrDefault(product => product.ProductID == item.ProductID);
                product.SoldCount += item.TotalQty;
                product.TotalQty -= item.TotalQty;
                _context.Products.Update(product);
                _context.SaveChanges();
            }
            HttpContext.Session.Clear();
            TempData["Message"] = "Your order has been placed.";
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult ClearCart()
        {
            HttpContext.Session.Clear();
            TempData["Message"] = "Your cart has been cleared.";
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            var session = new AmazonFreshSession(HttpContext.Session);
            var products = session.GetMyProducts();
            var product = products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                products.Remove(product);
                session.SetMyProducts(products);
                TempData["Message"] = $"{product.Name} Item removed successfully.";
            }
            return RedirectToAction("Index", "Cart");
        }
        [HttpPost]
        public IActionResult UpdateQuantity(int productId, int quantity)
        {
            var session = new AmazonFreshSession(HttpContext.Session);
            var products = session.GetMyProducts();
            var product = products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                product.TotalQty = quantity;
                session.SetMyProducts(products);
                TempData["Message"] = "Quantity updated successfully.";
            }
            return RedirectToAction("Index", "Cart");
        }

    }
}
