using AmazonFresh.Models;
using AmazonFresh.Models.DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AmazonFresh.Areas.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private AmazonFreshContext context;
        private List<Vendor> vendors;
        private List<Warehouse> warehouses;
        private List<Category> categories;
        private ProductRepository productData { get; set; }
        public ProductController(AmazonFreshContext ctx)
        {
            context = ctx;
            vendors = context.Vendors
                    .OrderBy(p => p.VendorID)
                    .ToList();
            warehouses = context.Warehouses
            .OrderBy(p => p.Name)
                    .ToList();
            categories = context.Categories
            .OrderBy(p => p.Name)
                    .ToList();
            productData = new ProductRepository(ctx);
        }
        [Route("[area]/[controller]")]
        public IActionResult Index(AmazonFreshViewModel model)//, string id)
        {
            var session = new AmazonFreshSession(HttpContext.Session);
            session.SetActiveDiv(model.ActiveVendor);
            session.SetActiveDiv(model.ActiveWarehouse);

            // if no count value in session, use data in cookie
            // to restore fave teams in session 
            int? count = session.GetMyTeamCount();
            if (!count.HasValue)
            {
                var cookies = new AmazonFreshCookies(Request.Cookies);
                string[] ids = cookies.GetMyTeamIds();

                if (ids.Length > 0)
                {
                    var myteams = context.Products
                        .Include(t => t.Vendor)
                        .Include(t => t.Warehouse)
                        .Include(t => t.Category)
                        .Where(t => ids.Contains(t.ProductID.ToString()))
                        .ToList();
                    session.SetMyProducts(myteams);
                }
            }

            // get conferences and divisions from database
            model.Categories = context.Categories.ToList();
            model.Warehouses = context.Warehouses.ToList();
            model.Vendors = context.Vendors.ToList();

            // get teams from database - filter by conference and division
            IQueryable<Product> query = context.Products.OrderBy(t => t.Name);
            if (model.ActiveCategory != "all")
                query = query.Where(
                    t => t.Category.CategoryID.ToString() == model.ActiveCategory);
            if (model.ActiveVendor != "all")
                query = query.Where(
                    t => t.Vendor.VendorID.ToString() == model.ActiveVendor);
            if (model.ActiveWarehouse != "all")
                query = query.Where(
                    t => t.Warehouse.WarehouseID.ToString() == model.ActiveWarehouse.ToLower());
            model.Products = query.Include(p => p.Category).Include(p => p.Vendor).Include(p => p.Warehouse).ToList();
            return View("List", model);

        }
        [Route("[area]/[controller]s")]
        public IActionResult List(AmazonFreshViewModel freshView/*, string id = "All"*/)
        {
            //if (id == "All")
            var products = productData.List(new QueryOptions<Product>
            {
                Includes = "Vendor, Warehouse",
                OrderBy = p => p.Name
            }).AsQueryable().Include(p => p.Warehouse).Include(p => p.Vendor).OrderBy(p => p.ProductID).ToList();
            
            freshView.Products = products.ToList();
            //else
            //    freshView.Products = context.Products.Include(p => p.Warehouse).Include(p => p.Vendor).Where(p => p.Vendor.Name == id)
            //        .OrderBy(p => p.ProductID).ToList();

            //// use ViewBag to pass category data to view
            //ViewBag.vendors = vendors;
            //ViewBag.selectedproduct = id;
            ////doctorView.Filters = new Filters(id-id-id);
            freshView.Categories = context.Categories.ToList();
            freshView.Vendors = context.Vendors.ToList();
            freshView.Warehouses = context.Warehouses.ToList();
            return View(freshView);
        }
        //[HttpPost]
        //public IActionResult Filter(string[] filter)
        //{
        //    string id = string.Join('-', filter);
        //    return RedirectToAction("Index", new { ID = id });
        //}
        [Route("[area]/[controller]/Add")]
        [HttpGet]
        public IActionResult Add()
        {
            Product products = new Product();
            ViewBag.Action = "Add";
            ViewBag.vendors = vendors;
            ViewBag.warehouses = warehouses;
            ViewBag.categories = categories;
            return View("AddUpdate", products);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            // get Product object for specified primary key
            Product product = context.Products.Include(p => p.Warehouse)
                .FirstOrDefault(p => p.ProductID == id) ?? new Product();

            // use ViewBag to pass action and speciality data to view
            ViewBag.Action = "Update";
            ViewBag.vendors = vendors;
            ViewBag.warehouses = warehouses;
            ViewBag.categories = categories;
            // bind product to AddUpdate view
            return View("AddUpdate", product);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                productData.AddOrUpdate(product);
                if (product.ProductImage != null)
                {
                    var fileName = $"{product.ProductID}{Path.GetExtension(product.ProductImage.FileName)}";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        product.ProductImage.CopyTo(stream);
                    }
                    //product.ProductImage = fileName;
                }
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Save";
                ViewBag.vendors = vendors;
                ViewBag.warehouses = warehouses;
                return View("AddUpdate", product);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product product = productData.Get(id) ?? new Product();
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            var productname = product.Name;
            productData.Delete(product); // cascading delete will get BookAuthors
            productData.Save();
            TempData["message"] = $"{productname} removed";
            return RedirectToAction("List");
        }

        [Route("[area]/[controller]s/{id}")]
        public IActionResult Detail(int id)
        {
            return Content("Product => Detail => ID: " + id + "  Area Admin Route");
        }
    }
}
