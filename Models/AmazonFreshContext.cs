using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace AmazonFresh.Models
{
    public class AmazonFreshContext : DbContext
    {
        public AmazonFreshContext(DbContextOptions<AmazonFreshContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Warehouse> Warehouses { get; set; } = null!;
        public DbSet<Vendor> Vendors { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Warehouse>().HasData(
                new Warehouse { WarehouseID = 1, Name = "Chennai" },
                new Warehouse { WarehouseID = 2, Name = "Andrapradesh" },
                new Warehouse { WarehouseID = 3, Name = "Hyderabad" }
            );
            modelBuilder.Entity<Vendor>().HasData(
                new Vendor { VendorID = 1, Name = "Sunrise Orchid" },
                new Vendor { VendorID = 2, Name = "Fruits Junction" },
                new Vendor { VendorID = 3, Name = "Fresh Topical Fruits" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductID = 1,
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
