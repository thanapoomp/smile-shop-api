using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmileShopAPI.Migrations
{
    public partial class add_table_productgroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("531e713a-f058-4797-94d5-f16285f30502"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("57e0bf9f-4625-4e39-a35a-a29d6bf7c910"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("62bfb6f0-98b7-43ec-a1ec-0db49dbbad03"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f5d39aee-3f36-4436-9aba-ec42628928f1"));

            migrationBuilder.CreateTable(
                name: "ProductGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroup", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("b7786e54-cb9d-4187-be48-d1e21d7c7080"), "user" },
                    { new Guid("3c169289-8433-4dde-a909-fc11645df049"), "Manager" },
                    { new Guid("14c50155-3b97-4ca9-ae45-593cf61954f0"), "Admin" },
                    { new Guid("a719ae14-3059-4664-9569-dfe39927507e"), "Developer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductGroup");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("14c50155-3b97-4ca9-ae45-593cf61954f0"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3c169289-8433-4dde-a909-fc11645df049"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a719ae14-3059-4664-9569-dfe39927507e"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b7786e54-cb9d-4187-be48-d1e21d7c7080"));

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("57e0bf9f-4625-4e39-a35a-a29d6bf7c910"), "user" },
                    { new Guid("f5d39aee-3f36-4436-9aba-ec42628928f1"), "Manager" },
                    { new Guid("531e713a-f058-4797-94d5-f16285f30502"), "Admin" },
                    { new Guid("62bfb6f0-98b7-43ec-a1ec-0db49dbbad03"), "Developer" }
                });
        }
    }
}
