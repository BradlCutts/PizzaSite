using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PizzaSite.Migrations
{
    public partial class OrderId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemSauce_OrderItems_OrderItemId",
                table: "OrderItemSauce");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemSauce_Sauces_SauceId",
                table: "OrderItemSauce");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemTopping_OrderItems_OrderItemId",
                table: "OrderItemTopping");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemTopping_Toppings_ToppingId",
                table: "OrderItemTopping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItemTopping",
                table: "OrderItemTopping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItemSauce",
                table: "OrderItemSauce");

            migrationBuilder.RenameTable(
                name: "OrderItemTopping",
                newName: "OrderItemToppings");

            migrationBuilder.RenameTable(
                name: "OrderItemSauce",
                newName: "OrderItemSauces");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItemTopping_OrderItemId",
                table: "OrderItemToppings",
                newName: "IX_OrderItemToppings_OrderItemId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItemSauce_OrderItemId",
                table: "OrderItemSauces",
                newName: "IX_OrderItemSauces_OrderItemId");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrderItems",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItemToppings",
                table: "OrderItemToppings",
                columns: new[] { "ToppingId", "OrderItemId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItemSauces",
                table: "OrderItemSauces",
                columns: new[] { "SauceId", "OrderItemId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemSauces_OrderItems_OrderItemId",
                table: "OrderItemSauces",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemSauces_Sauces_SauceId",
                table: "OrderItemSauces",
                column: "SauceId",
                principalTable: "Sauces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemToppings_OrderItems_OrderItemId",
                table: "OrderItemToppings",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemToppings_Toppings_ToppingId",
                table: "OrderItemToppings",
                column: "ToppingId",
                principalTable: "Toppings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemSauces_OrderItems_OrderItemId",
                table: "OrderItemSauces");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemSauces_Sauces_SauceId",
                table: "OrderItemSauces");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemToppings_OrderItems_OrderItemId",
                table: "OrderItemToppings");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemToppings_Toppings_ToppingId",
                table: "OrderItemToppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItemToppings",
                table: "OrderItemToppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItemSauces",
                table: "OrderItemSauces");

            migrationBuilder.RenameTable(
                name: "OrderItemToppings",
                newName: "OrderItemTopping");

            migrationBuilder.RenameTable(
                name: "OrderItemSauces",
                newName: "OrderItemSauce");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItemToppings_OrderItemId",
                table: "OrderItemTopping",
                newName: "IX_OrderItemTopping_OrderItemId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItemSauces_OrderItemId",
                table: "OrderItemSauce",
                newName: "IX_OrderItemSauce_OrderItemId");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrderItems",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItemTopping",
                table: "OrderItemTopping",
                columns: new[] { "ToppingId", "OrderItemId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItemSauce",
                table: "OrderItemSauce",
                columns: new[] { "SauceId", "OrderItemId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemSauce_OrderItems_OrderItemId",
                table: "OrderItemSauce",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemSauce_Sauces_SauceId",
                table: "OrderItemSauce",
                column: "SauceId",
                principalTable: "Sauces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemTopping_OrderItems_OrderItemId",
                table: "OrderItemTopping",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemTopping_Toppings_ToppingId",
                table: "OrderItemTopping",
                column: "ToppingId",
                principalTable: "Toppings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
