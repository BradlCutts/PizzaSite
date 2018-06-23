using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PizzaSite.Migrations
{
    public partial class yup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemSuaces_MenuItems_MenuItemId",
                table: "MenuItemSuaces");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemSuaces_Sauces_SauceId",
                table: "MenuItemSuaces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItemSuaces",
                table: "MenuItemSuaces");

            migrationBuilder.RenameTable(
                name: "MenuItemSuaces",
                newName: "MenuItemSauces");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItemSuaces_MenuItemId",
                table: "MenuItemSauces",
                newName: "IX_MenuItemSauces_MenuItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItemSauces",
                table: "MenuItemSauces",
                columns: new[] { "SauceId", "MenuItemId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemSauces_MenuItems_MenuItemId",
                table: "MenuItemSauces",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemSauces_Sauces_SauceId",
                table: "MenuItemSauces",
                column: "SauceId",
                principalTable: "Sauces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemSauces_MenuItems_MenuItemId",
                table: "MenuItemSauces");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemSauces_Sauces_SauceId",
                table: "MenuItemSauces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItemSauces",
                table: "MenuItemSauces");

            migrationBuilder.RenameTable(
                name: "MenuItemSauces",
                newName: "MenuItemSuaces");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItemSauces_MenuItemId",
                table: "MenuItemSuaces",
                newName: "IX_MenuItemSuaces_MenuItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItemSuaces",
                table: "MenuItemSuaces",
                columns: new[] { "SauceId", "MenuItemId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemSuaces_MenuItems_MenuItemId",
                table: "MenuItemSuaces",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemSuaces_Sauces_SauceId",
                table: "MenuItemSuaces",
                column: "SauceId",
                principalTable: "Sauces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
