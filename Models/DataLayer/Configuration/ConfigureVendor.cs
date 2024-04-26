using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using AmazonFresh.Models;

namespace AmazonFresh.Models
{
    internal class ConfigureVendor : IEntityTypeConfiguration<Vendor>
	{
		public void Configure(EntityTypeBuilder<Vendor> entity)
		{
			// seed initial data
			entity.HasData(
				new Vendor { VendorID = 1, Name = "Sunrise Orchid" },
				new Vendor { VendorID = 2, Name = "Fruits Junction" },
				new Vendor { VendorID = 3, Name = "Fresh Topical Fruits" }
			);
		}
	}
}
