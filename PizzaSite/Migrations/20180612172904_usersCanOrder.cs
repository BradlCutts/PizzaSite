using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PizzaSite.Migrations
{
    public partial class usersCanOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "customerId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuItemId",
                table: "OrderItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_customerId",
                table: "Orders",
                column: "customerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_customerId",
                table: "Orders",
                column: "customerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_customerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_customerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "customerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MenuItemId",
                table: "OrderItems");
        }
    }
}
