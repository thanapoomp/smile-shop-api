using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmileShopAPI.Migrations
{
    public partial class add_relationship_stockedit_product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { new Guid("e16d7c16-8a84-4b73-8622-1655e1d17e10"), "user" },
                    { new Guid("85d30765-72ec-4e15-967e-23188fecd32e"), "Manager" },
                    { new Guid("0c46075b-7c6a-4799-b862-1d6442885813"), "Admin" },
                    { new Guid("33bfacf9-bb80-4e06-bdd5-25fbe52ef353"), "Developer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockEditLog_ProductId",
                table: "StockEditLog",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockEditLog_Products_ProductId",
                table: "StockEditLog",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockEditLog_Products_ProductId",
                table: "StockEditLog");

            migrationBuilder.DropIndex(
                name: "IX_StockEditLog_ProductId",
                table: "StockEditLog");

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
    }
}
