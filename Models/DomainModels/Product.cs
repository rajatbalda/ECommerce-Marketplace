using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AmazonFresh.Models
{
    public class Product
    {

        public int ProductID { get; set; }

        [Required(ErrorMessage = "Select Category")]
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Select Warehouse")]
        public int WarehouseID { get; set; }
        [Required(ErrorMessage = "Select Vendor")]
        public int VendorID { get; set; }

        [Required(ErrorMessage = "Enter product name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter unit price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Select Unit")]
        public string Unit { get; set; } = string.Empty;
        [Required(ErrorMessage = "Product Description")]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Total Quantity")]
        public int TotalQty { get; set; }
        [Required(ErrorMessage = "On Sale")]
        public int onSale { get; set; }
        [Required(ErrorMessage = "Stock Time")]
        public DateTime StockTimestamp { get; set; } = DateTime.Now;

        [NotMapped]
        public IFormFile? ProductImage { get; set; }

        public int SoldCount { get; set; }

        [ValidateNever]
        public Warehouse Warehouse { get; set; } = null!;
        [ValidateNever]
        public Vendor Vendor { get; set; } = null!;
        [ValidateNever]
        public Category Category { get; set; } = null!;
    }
}
