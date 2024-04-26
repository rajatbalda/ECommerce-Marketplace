using System.ComponentModel.DataAnnotations;

namespace AmazonFresh.Models
{
    public class Vendor
    {
        public int VendorID { get; set; }

        [Required(ErrorMessage = "Enter a Vendor")]
        public string Name { get; set; } = string.Empty;

    }
}
