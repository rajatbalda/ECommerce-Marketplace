using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AmazonFresh.Models;

namespace AmazonFresh.Models
{
    internal class ConfigureProduct : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> entity)
		{
			// seed initial data
			entity.HasData(
				 new Product
				 {
					 ProductID = 1,
					 CategoryID = 1,
					 Price = Convert.ToDecimal("2.99"),
					 WarehouseID = 1,
					 VendorID = 1,
					 Name = "Jammu Apple",
					 Unit = "gram",
					 SoldCount = 10,
					 Description = "Fresh, juicy apples from the orchards of Jammu. Crisp and delicious, perfect for snacking.",
					 onSale = 0,
					 StockTimestamp = DateTime.Now.AddDays(-5),
					 TotalQty = 15
				 }, new Product
				 {
					 ProductID = 2,
                     CategoryID = 1,
                     Price = Convert.ToDecimal("10.79"),
					 WarehouseID = 1,
					 VendorID = 1,
					 Name = "Blue Berries",
					 Unit = "gram",
					 SoldCount = 26,
					 Description = "Plump, flavorful berries bursting with antioxidants and natural sweetness.",
					 onSale = 1,
					 StockTimestamp = DateTime.Now.AddDays(6),
					 TotalQty = 15
				 }, new Product
				 {
					 ProductID = 3,
                     CategoryID = 1,
                     Price = Convert.ToDecimal("0.79"),
					 WarehouseID = 2,
					 VendorID = 2,
					 Name = "Rasberries",
					 Unit = "gram",
					 SoldCount = 31,
					 Description = "Tangy and succulent berries with vibrant color and refreshing taste.",
					 onSale = 1,
					 StockTimestamp = DateTime.Now,
					 TotalQty = 5
				 }, new Product
				 {
					 ProductID = 4,
                     CategoryID = 1,
                     Price = Convert.ToDecimal("10.79"),
					 WarehouseID = 1,
					 VendorID = 2,
					 Name = "Kiwi",
					 Unit = "gram",
					 SoldCount = 1,
					 Description = "Fresh and tangy kiwis",
					 onSale = 1,
					 StockTimestamp = DateTime.Now,
					 TotalQty = 7
				 }, new Product
				 {
					 ProductID = 5,
                     CategoryID = 1,
                     Price = Convert.ToDecimal("100.79"),
					 WarehouseID = 2,
					 VendorID = 2,
					 Name = "GrapeFruits",
					 Unit = "box",
					 SoldCount = 5,
					 Description = "Citrusy, juicy fruits with a tangy-sweet flavor, packed with vitamin C.",
					 onSale = 0,
					 StockTimestamp = DateTime.Now,
					 TotalQty = 3
				 }
			);
		}
	}
}
