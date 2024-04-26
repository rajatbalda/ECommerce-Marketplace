using System.ComponentModel.DataAnnotations;

namespace AmazonFresh.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Enter a Category")]
        public string Name { get; set; } = string.Empty;
    }
}
