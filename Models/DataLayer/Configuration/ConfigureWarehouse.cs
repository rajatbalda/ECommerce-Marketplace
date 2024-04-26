using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AmazonFresh.Models;

namespace AmazonFresh.Models
{

    internal class ConfigureWarehouse : IEntityTypeConfiguration<Warehouse>
	{
		public void Configure(EntityTypeBuilder<Warehouse> entity)
		{
			// seed initial data
			entity.HasData(
				 new Warehouse { WarehouseID = 1, Name = "Chennai" },
			new Warehouse { WarehouseID = 2, Name = "Andrapradesh" },
			new Warehouse { WarehouseID = 3, Name = "Hyderabad" }
			);
		}
	}
}
