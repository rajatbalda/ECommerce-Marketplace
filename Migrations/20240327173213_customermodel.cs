using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmazonFresh.Migrations
{
    /// <inheritdoc />
    public partial class customermodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1,
                columns: new[] { "Description", "StockTimestamp" },
                values: new object[] { "Fresh, juicy apples from the orchards of Jammu. Crisp and delicious, perfect for snacking.", new DateTime(2024, 3, 22, 23, 2, 12, 37, DateTimeKind.Local).AddTicks(540) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2,
                columns: new[] { "Description", "StockTimestamp" },
                values: new object[] { "Plump, flavorful berries bursting with antioxidants and natural sweetness.", new DateTime(2024, 4, 2, 23, 2, 12, 37, DateTimeKind.Local).AddTicks(550) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3,
                columns: new[] { "Description", "StockTimestamp" },
                values: new object[] { "Tangy and succulent berries with vibrant color and refreshing taste.", new DateTime(2024, 3, 27, 23, 2, 12, 37, DateTimeKind.Local).AddTicks(555) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4,
                columns: new[] { "Description", "StockTimestamp" },
                values: new object[] { "Citrusy, juicy fruits with a tangy-sweet flavor, packed with vitamin C.", new DateTime(2024, 3, 27, 23, 2, 12, 37, DateTimeKind.Local).AddTicks(559) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1,
                columns: new[] { "Description", "StockTimestamp" },
                values: new object[] { "Jammu Apple: Fresh, juicy apples from the orchards of Jammu. Crisp and delicious, perfect for snacking.", new DateTime(2024, 3, 21, 21, 39, 49, 742, DateTimeKind.Local).AddTicks(9682) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2,
                columns: new[] { "Description", "StockTimestamp" },
                values: new object[] { "Blue Berries: Plump, flavorful berries bursting with antioxidants and natural sweetness.", new DateTime(2024, 4, 1, 21, 39, 49, 742, DateTimeKind.Local).AddTicks(9719) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3,
                columns: new[] { "Description", "StockTimestamp" },
                values: new object[] { "Raspberries: Tangy and succulent berries with vibrant color and refreshing taste.", new DateTime(2024, 3, 26, 21, 39, 49, 742, DateTimeKind.Local).AddTicks(9726) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4,
                columns: new[] { "Description", "StockTimestamp" },
                values: new object[] { "Grapefruits: Citrusy, juicy fruits with a tangy-sweet flavor, packed with vitamin C.", new DateTime(2024, 3, 26, 21, 39, 49, 742, DateTimeKind.Local).AddTicks(9732) });
        }
    }
}
