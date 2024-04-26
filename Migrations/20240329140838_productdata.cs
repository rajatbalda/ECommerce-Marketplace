using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmazonFresh.Migrations
{
    /// <inheritdoc />
    public partial class productdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1,
                column: "StockTimestamp",
                value: new DateTime(2024, 3, 24, 19, 38, 36, 125, DateTimeKind.Local).AddTicks(8054));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2,
                column: "StockTimestamp",
                value: new DateTime(2024, 4, 4, 19, 38, 36, 125, DateTimeKind.Local).AddTicks(8071));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3,
                column: "StockTimestamp",
                value: new DateTime(2024, 3, 29, 19, 38, 36, 125, DateTimeKind.Local).AddTicks(8077));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4,
                columns: new[] { "Description", "Name", "Price", "SoldCount", "StockTimestamp", "TotalQty", "Unit", "WarehouseID", "onSale" },
                values: new object[] { "Fresh and tangy kiwis", "Kiwi", 10.79m, 1, new DateTime(2024, 3, 29, 19, 38, 36, 125, DateTimeKind.Local).AddTicks(8083), 7, "gram", 1, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "Description", "Name", "Price", "SoldCount", "StockTimestamp", "TotalQty", "Unit", "VendorID", "WarehouseID", "onSale" },
                values: new object[] { 5, "Citrusy, juicy fruits with a tangy-sweet flavor, packed with vitamin C.", "GrapeFruits", 100.79m, 5, new DateTime(2024, 3, 29, 19, 38, 36, 125, DateTimeKind.Local).AddTicks(8090), 3, "box", 2, 2, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1,
                column: "StockTimestamp",
                value: new DateTime(2024, 3, 22, 23, 2, 12, 37, DateTimeKind.Local).AddTicks(540));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2,
                column: "StockTimestamp",
                value: new DateTime(2024, 4, 2, 23, 2, 12, 37, DateTimeKind.Local).AddTicks(550));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3,
                column: "StockTimestamp",
                value: new DateTime(2024, 3, 27, 23, 2, 12, 37, DateTimeKind.Local).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4,
                columns: new[] { "Description", "Name", "Price", "SoldCount", "StockTimestamp", "TotalQty", "Unit", "WarehouseID", "onSale" },
                values: new object[] { "Citrusy, juicy fruits with a tangy-sweet flavor, packed with vitamin C.", "GrapeFruits", 100.79m, 5, new DateTime(2024, 3, 27, 23, 2, 12, 37, DateTimeKind.Local).AddTicks(559), 3, "box", 2, 0 });
        }
    }
}
