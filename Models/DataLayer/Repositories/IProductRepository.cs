namespace AmazonFresh.Models.DataLayer.Repositories
{
	public interface IProductRepository : IRepository<Product>
	{
		void AddOrUpdate(Product product);
	}
}
