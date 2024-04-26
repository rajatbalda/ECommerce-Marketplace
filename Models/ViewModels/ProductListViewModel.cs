namespace AmazonFresh.Models
{
	public class ProductListViewModel
	{		
			public IEnumerable<Product> Products { get; set; } = new List<Product>();
			public ProductGridData CurrentRoute { get; set; } = new ProductGridData();
			public int TotalPages { get; set; }
	}
}
