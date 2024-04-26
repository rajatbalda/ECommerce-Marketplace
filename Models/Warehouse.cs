using System.ComponentModel.DataAnnotations;

namespace AmazonFresh.Models
{
    public class Warehouse
    {
        public int WarehouseID { get; set; }

        [Required(ErrorMessage = "Enter a warehouse")]
        public string Name { get; set; } = string.Empty;
    }
}
