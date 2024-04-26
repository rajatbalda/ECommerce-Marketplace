namespace AmazonFresh.Models.DataLayer.Repositories
{	public class ProductRepository : Repository<Product>, IProductRepository
	{
		public ProductRepository(AmazonFreshContext ctx) : base(ctx) { }

		public void AddOrUpdate(Product product)
		{
			if (product.ProductID == 0) 
			{
				Insert(product);
			}
			else 
			{
				Update(product);
			}

			Save();
		}
	}
}
