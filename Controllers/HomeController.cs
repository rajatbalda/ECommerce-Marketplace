using AmazonFresh.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AmazonFresh.Controllers
{
    public class HomeController : Controller
    {
        private readonly AmazonFreshContext _context;
        private Repository<Product> data { get; set; }


        public HomeController(AmazonFreshContext context)
        {
            _context = context;
            data = new Repository<Product>(context);
        }
        [Route("/")]
        public IActionResult Index(AmazonFreshViewModel model, ProductGridData values)
        {
            model.Filters = new Filters(model.ActiveCategory + "-" + model.ActivePrice + "-" + model.ActiveSpecial);
            var options = new QueryOptions<Product>
            {
                Includes = "Vendor, Warehouse",
                OrderByDirection = values.SortDirection,
                PageNumber = values.PageNumber,
                PageSize = values.PageSize
            };
            
            if (values.IsSortByPriceLowToHigh)
                options.OrderBy = b => b.Price;
            else if (values.IsSoldCount)
                options.OrderBy = b => b.SoldCount;
            else if (values.IsSortByPriceHighToLow)
                options.OrderBy = b => b.Price;
            // create view model
            var vm = new ProductListViewModel
            {
                Products = data.List(options),
                CurrentRoute = values,
                TotalPages = values.GetTotalPages(data.Count)
            };
            IQueryable<Product> query = vm.Products.AsQueryable().Include(t => t.Vendor).Include(t => t.Warehouse).Include(t => t.Category);
            if (model.ActiveCategory != "all")
                query = query.Where(
                    t => t.CategoryID.ToString() == model.ActiveCategory.ToString());
            if (model.ActivePrice != "all")
                query = query.Where(
                    t => t.Price <= Convert.ToDecimal(model.ActivePrice));
            if (model.ActiveSpecial != "all" && model.ActiveSpecial == "New Arrival")
                query = query.Where(t => t.StockTimestamp >= DateTime.Now.AddHours(-24));
            else if (model.ActiveSpecial != "all" && model.ActiveSpecial == "Best Seller")
                query = query.Where(t => t.SoldCount >= 2);
            else if (model.ActiveSpecial != "all" && model.ActiveSpecial == "On Sale")
                query = query.Where(t => t.onSale == 1);
            model.Categories = _context.Categories.ToList();
            //model.Products = query.OrderBy(q=>q.Name).ToList();
            model.Products = query.ToList();
            model.CurrentRoute = vm.CurrentRoute;
            model.TotalPages = vm.TotalPages;
            return View(model);
        }
        public IActionResult ProductDetails(int productId)
        {
            AmazonFreshViewModel model = new AmazonFreshViewModel();
            model.Product = _context.Products?.Find(productId);
            return View(model);
        }
        [Route("Category")]
        public IActionResult Category()
        {
            return Content("Regular Page => Home => Category");
        }
    }
}
