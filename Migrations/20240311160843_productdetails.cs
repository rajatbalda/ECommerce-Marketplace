using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AmazonFresh.Migrations
{
    /// <inheritdoc />
    public partial class productdetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "Name", "Price", "SoldCount", "Unit", "VendorID", "WarehouseID" },
                values: new object[,]
                {
                    { 2, "Blue Berries", 10.79m, 26, "gram", 1, 1 },
                    { 3, "Rasberries", 0.79m, 31, "gram", 2, 2 },
                    { 4, "GrapeFruits", 100.79m, 5, "box", 2, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: 1,
                column: "Name",
                value: "Sunrise Orchid");

            migrationBuilder.UpdateData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: 2,
                column: "Name",
                value: "Fruits Junction");

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "VendorID", "Name" },
                values: new object[] { 3, "Fresh Topical Fruits" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: 1,
                column: "Name",
                value: "Sunrise");

            migrationBuilder.UpdateData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: 2,
                column: "Name",
                value: "Orchid");
        }
    }
}
