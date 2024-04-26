using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmazonFresh.Migrations
{
    /// <inheritdoc />
    public partial class productmodify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "StockTimestamp",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TotalQty",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "onSale",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1,
                columns: new[] { "Description", "StockTimestamp", "TotalQty", "onSale" },
                values: new object[] { "Fresh, juicy apples from the orchards of Jammu. Crisp and delicious, perfect for snacking.", new DateTime(2024, 3, 21, 21, 39, 49, 742, DateTimeKind.Local).AddTicks(9682), 15, 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2,
                columns: new[] { "Description", "StockTimestamp", "TotalQty", "onSale" },
                values: new object[] { "Plump, flavorful berries bursting with antioxidants and natural sweetness.", new DateTime(2024, 4, 1, 21, 39, 49, 742, DateTimeKind.Local).AddTicks(9719), 15, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3,
                columns: new[] { "Description", "StockTimestamp", "TotalQty", "onSale" },
                values: new object[] { "Tangy and succulent berries with vibrant color and refreshing taste.", new DateTime(2024, 3, 26, 21, 39, 49, 742, DateTimeKind.Local).AddTicks(9726), 5, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4,
                columns: new[] { "Description", "StockTimestamp", "TotalQty", "onSale" },
                values: new object[] { " Citrusy, juicy fruits with a tangy-sweet flavor, packed with vitamin C.", new DateTime(2024, 3, 26, 21, 39, 49, 742, DateTimeKind.Local).AddTicks(9732), 3, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StockTimestamp",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TotalQty",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "onSale",
                table: "Products");
        }
    }
}
