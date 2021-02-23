using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmileShopAPI.Migrations
{
    public partial class add_stockEditLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "StockEditLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    AmountBefore = table.Column<int>(nullable: false),
                    AmountNumber = table.Column<int>(nullable: false),
                    AmountAfter = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockEditLog", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("bb02b1c3-ff4b-42e4-a034-a560a7cdb6f4"), "user" },
                    { new Guid("7b4e1168-f374-44f4-bf97-4b74fb296655"), "Manager" },
                    { new Guid("3e249c9b-7962-43db-a3a7-f1d3a6d1e98d"), "Admin" },
                    { new Guid("4957d07c-87f9-4cba-aff2-1a2221678c94"), "Developer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockEditLog");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3e249c9b-7962-43db-a3a7-f1d3a6d1e98d"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("4957d07c-87f9-4cba-aff2-1a2221678c94"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("7b4e1168-f374-44f4-bf97-4b74fb296655"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("bb02b1c3-ff4b-42e4-a034-a560a7cdb6f4"));

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
        }
    }
}
