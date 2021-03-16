using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmileShopAPI.Migrations
{
    public partial class add_order_and_orderDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("1566762e-f18b-4a95-af56-9dda27385fd3"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("69c6a9fa-d4f1-47e5-ae7c-c0f536e496d8"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("6f0bdda1-c44b-48bd-9fda-2b4d2a47a332"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("9cf68386-f751-4253-97ca-0bfd80bf05a8"));

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<double>(nullable: false),
                    Discount = table.Column<double>(nullable: false),
                    NetTotal = table.Column<double>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    PricePerUnit = table.Column<double>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("fa99d514-9cad-4e1b-9120-efa2e9aaf2c3"), "user" },
                    { new Guid("aaa169e4-4a00-4844-8c7f-ae76eb2e6e5a"), "Manager" },
                    { new Guid("18ec4612-8b67-4171-b1f3-8add2aa7c50c"), "Admin" },
                    { new Guid("5f6ed07b-c456-42e9-b7ce-b4c35f59157a"), "Developer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("18ec4612-8b67-4171-b1f3-8add2aa7c50c"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("5f6ed07b-c456-42e9-b7ce-b4c35f59157a"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("aaa169e4-4a00-4844-8c7f-ae76eb2e6e5a"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("fa99d514-9cad-4e1b-9120-efa2e9aaf2c3"));

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("9cf68386-f751-4253-97ca-0bfd80bf05a8"), "user" },
                    { new Guid("1566762e-f18b-4a95-af56-9dda27385fd3"), "Manager" },
                    { new Guid("69c6a9fa-d4f1-47e5-ae7c-c0f536e496d8"), "Admin" },
                    { new Guid("6f0bdda1-c44b-48bd-9fda-2b4d2a47a332"), "Developer" }
                });
        }
    }
}
