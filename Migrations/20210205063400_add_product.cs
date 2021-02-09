using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmileShopAPI.Migrations
{
    public partial class add_product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("30eabf5b-d596-4c67-9c5a-7b293989f5b3"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("38a7a60d-a768-4cb7-bd2b-8574a27c20cb"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("5c0ee005-e55f-4f72-9373-9347bff9ea91"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("e71fa5b0-1fe0-4889-9dbb-4eb2e624bba3"));

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    ProductGroupId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductGroup_ProductGroupId",
                        column: x => x.ProductGroupId,
                        principalTable: "ProductGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("cec71dec-d5f4-4d71-a966-d3fb59740bb7"), "user" },
                    { new Guid("af20e3da-081b-475e-8c25-8a144c686e7c"), "Manager" },
                    { new Guid("7c6079d2-90e5-4171-82db-57063dc64802"), "Admin" },
                    { new Guid("c48b38c4-3811-4376-8d3f-01f7811c8bdc"), "Developer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductGroupId",
                table: "Products",
                column: "ProductGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("7c6079d2-90e5-4171-82db-57063dc64802"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("af20e3da-081b-475e-8c25-8a144c686e7c"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("c48b38c4-3811-4376-8d3f-01f7811c8bdc"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("cec71dec-d5f4-4d71-a966-d3fb59740bb7"));

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("e71fa5b0-1fe0-4889-9dbb-4eb2e624bba3"), "user" },
                    { new Guid("30eabf5b-d596-4c67-9c5a-7b293989f5b3"), "Manager" },
                    { new Guid("38a7a60d-a768-4cb7-bd2b-8574a27c20cb"), "Admin" },
                    { new Guid("5c0ee005-e55f-4f72-9373-9347bff9ea91"), "Developer" }
                });
        }
    }
}
