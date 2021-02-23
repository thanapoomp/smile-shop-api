using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmileShopAPI.Migrations
{
    public partial class add_employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("0c46075b-7c6a-4799-b862-1d6442885813"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("33bfacf9-bb80-4e06-bdd5-25fbe52ef353"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("85d30765-72ec-4e15-967e-23188fecd32e"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("e16d7c16-8a84-4b73-8622-1655e1d17e10"));

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Occupation = table.Column<string>(nullable: true),
                    ImageName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

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

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("e16d7c16-8a84-4b73-8622-1655e1d17e10"), "user" },
                    { new Guid("85d30765-72ec-4e15-967e-23188fecd32e"), "Manager" },
                    { new Guid("0c46075b-7c6a-4799-b862-1d6442885813"), "Admin" },
                    { new Guid("33bfacf9-bb80-4e06-bdd5-25fbe52ef353"), "Developer" }
                });
        }
    }
}
