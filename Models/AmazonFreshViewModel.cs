using System.ComponentModel.DataAnnotations;

namespace AmazonFresh.Models
{
    public class AmazonFreshViewModel
    {
        public Filters Filters { get; set; } = new Filters("all-all-all");
        public string ActiveCategory { get; set; } = "all";
        public string ActivePrice { get; set; } = "all";
        public string ActiveSpecial { get; set; } = "all";
        public string CheckActiveCat(string c) =>
            c.ToLower() == ActiveCategory.ToLower() ? "active" : "";

        public string CheckActivePrice(string d) =>
            d.ToLower() == ActivePrice.ToLower() ? "active" : "";
        public string CheckActiveSpecial(string d) =>
            d.ToLower() == ActiveSpecial.ToLower() ? "active" : "";
        public string ActiveVendor { get; set; } = "all";
        public string ActiveWarehouse { get; set; } = "all";
        public List<Vendor> Vendors { get; set; } = new List<Vendor>();
        public List<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
        //public Dictionary<string, string> DueFilters { get; set; } = new Dictionary<string, string>();
        public List<Product> Products { get; set; } = new List<Product>();
        public Product Product { get; set; } = new Product();
        public string CheckActiveVendor(string v) =>
            v.ToLower() == ActiveVendor.ToLower() ? "active" : "";

        public string CheckActiveWarehouse(string w) =>
            w.ToLower() == ActiveWarehouse.ToLower() ? "active" : "";
    }
    public class LoginViewModel
    {       [Required]
            public string Username { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
     
    }
}