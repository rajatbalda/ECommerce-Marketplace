using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AmazonFresh.Migrations
{
    /// <inheritdoc />
    public partial class configuredatas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[,]
                {
                    { 1, "Fruits" },
                    { 2, "Vegetables" },
                    { 3, "Sweets" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1,
                columns: new[] { "CategoryID", "StockTimestamp" },
                values: new object[] { 1, new DateTime(2024, 4, 16, 11, 12, 38, 928, DateTimeKind.Local).AddTicks(4939) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2,
                columns: new[] { "CategoryID", "StockTimestamp" },
                values: new object[] { 1, new DateTime(2024, 4, 27, 11, 12, 38, 928, DateTimeKind.Local).AddTicks(4951) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3,
                columns: new[] { "CategoryID", "StockTimestamp" },
                values: new object[] { 1, new DateTime(2024, 4, 21, 11, 12, 38, 928, DateTimeKind.Local).AddTicks(4957) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4,
                columns: new[] { "CategoryID", "StockTimestamp" },
                values: new object[] { 1, new DateTime(2024, 4, 21, 11, 12, 38, 928, DateTimeKind.Local).AddTicks(4961) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5,
                columns: new[] { "CategoryID", "StockTimestamp" },
                values: new object[] { 1, new DateTime(2024, 4, 21, 11, 12, 38, 928, DateTimeKind.Local).AddTicks(4967) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Products");

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
                column: "StockTimestamp",
                value: new DateTime(2024, 3, 29, 19, 38, 36, 125, DateTimeKind.Local).AddTicks(8083));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5,
                column: "StockTimestamp",
                value: new DateTime(2024, 3, 29, 19, 38, 36, 125, DateTimeKind.Local).AddTicks(8090));
        }
    }
}
