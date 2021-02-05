using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmileShopAPI.Migrations
{
    public partial class AddProductGroupColumnIconName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "IconName",
                table: "ProductGroup",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IconName",
                table: "ProductGroup");

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
    }
}
