using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PizzaSite.Migrations
{
    public partial class abc2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemCrust_Crusts_CrustId",
                table: "MenuItemCrust");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemCrust_MenuItems_MenuItemId",
                table: "MenuItemCrust");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemCut_Cuts_CutId",
                table: "MenuItemCut");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemCut_MenuItems_MenuItemId",
                table: "MenuItemCut");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemSauce_MenuItems_MenuItemId",
                table: "MenuItemSauce");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemSauce_Sauces_SauceId",
                table: "MenuItemSauce");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemTopping_MenuItems_MenuItemId",
                table: "MenuItemTopping");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemTopping_Toppings_ToppingId",
                table: "MenuItemTopping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItemTopping",
                table: "MenuItemTopping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItemSauce",
                table: "MenuItemSauce");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItemCut",
                table: "MenuItemCut");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItemCrust",
                table: "MenuItemCrust");

            migrationBuilder.RenameTable(
                name: "MenuItemTopping",
                newName: "MenuItemToppings");

            migrationBuilder.RenameTable(
                name: "MenuItemSauce",
                newName: "MenuItemSuaces");

            migrationBuilder.RenameTable(
                name: "MenuItemCut",
                newName: "MenuItemCuts");

            migrationBuilder.RenameTable(
                name: "MenuItemCrust",
                newName: "MenuItemCrusts");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItemTopping_MenuItemId",
                table: "MenuItemToppings",
                newName: "IX_MenuItemToppings_MenuItemId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItemSauce_MenuItemId",
                table: "MenuItemSuaces",
                newName: "IX_MenuItemSuaces_MenuItemId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItemCut_MenuItemId",
                table: "MenuItemCuts",
                newName: "IX_MenuItemCuts_MenuItemId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItemCrust_MenuItemId",
                table: "MenuItemCrusts",
                newName: "IX_MenuItemCrusts_MenuItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItemToppings",
                table: "MenuItemToppings",
                columns: new[] { "ToppingId", "MenuItemId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItemSuaces",
                table: "MenuItemSuaces",
                columns: new[] { "SauceId", "MenuItemId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItemCuts",
                table: "MenuItemCuts",
                columns: new[] { "CutId", "MenuItemId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItemCrusts",
                table: "MenuItemCrusts",
                columns: new[] { "CrustId", "MenuItemId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemCrusts_Crusts_CrustId",
                table: "MenuItemCrusts",
                column: "CrustId",
                principalTable: "Crusts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemCrusts_MenuItems_MenuItemId",
                table: "MenuItemCrusts",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemCuts_Cuts_CutId",
                table: "MenuItemCuts",
                column: "CutId",
                principalTable: "Cuts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemCuts_MenuItems_MenuItemId",
                table: "MenuItemCuts",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemToppings_MenuItems_MenuItemId",
                table: "MenuItemToppings",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemToppings_Toppings_ToppingId",
                table: "MenuItemToppings",
                column: "ToppingId",
                principalTable: "Toppings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemCrusts_Crusts_CrustId",
                table: "MenuItemCrusts");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemCrusts_MenuItems_MenuItemId",
                table: "MenuItemCrusts");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemCuts_Cuts_CutId",
                table: "MenuItemCuts");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemCuts_MenuItems_MenuItemId",
                table: "MenuItemCuts");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemSuaces_MenuItems_MenuItemId",
                table: "MenuItemSuaces");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemSuaces_Sauces_SauceId",
                table: "MenuItemSuaces");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemToppings_MenuItems_MenuItemId",
                table: "MenuItemToppings");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemToppings_Toppings_ToppingId",
                table: "MenuItemToppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItemToppings",
                table: "MenuItemToppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItemSuaces",
                table: "MenuItemSuaces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItemCuts",
                table: "MenuItemCuts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItemCrusts",
                table: "MenuItemCrusts");

            migrationBuilder.RenameTable(
                name: "MenuItemToppings",
                newName: "MenuItemTopping");

            migrationBuilder.RenameTable(
                name: "MenuItemSuaces",
                newName: "MenuItemSauce");

            migrationBuilder.RenameTable(
                name: "MenuItemCuts",
                newName: "MenuItemCut");

            migrationBuilder.RenameTable(
                name: "MenuItemCrusts",
                newName: "MenuItemCrust");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItemToppings_MenuItemId",
                table: "MenuItemTopping",
                newName: "IX_MenuItemTopping_MenuItemId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItemSuaces_MenuItemId",
                table: "MenuItemSauce",
                newName: "IX_MenuItemSauce_MenuItemId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItemCuts_MenuItemId",
                table: "MenuItemCut",
                newName: "IX_MenuItemCut_MenuItemId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItemCrusts_MenuItemId",
                table: "MenuItemCrust",
                newName: "IX_MenuItemCrust_MenuItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItemTopping",
                table: "MenuItemTopping",
                columns: new[] { "ToppingId", "MenuItemId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItemSauce",
                table: "MenuItemSauce",
                columns: new[] { "SauceId", "MenuItemId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItemCut",
                table: "MenuItemCut",
                columns: new[] { "CutId", "MenuItemId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItemCrust",
                table: "MenuItemCrust",
                columns: new[] { "CrustId", "MenuItemId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemCrust_Crusts_CrustId",
                table: "MenuItemCrust",
                column: "CrustId",
                principalTable: "Crusts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemCrust_MenuItems_MenuItemId",
                table: "MenuItemCrust",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemCut_Cuts_CutId",
                table: "MenuItemCut",
                column: "CutId",
                principalTable: "Cuts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemCut_MenuItems_MenuItemId",
                table: "MenuItemCut",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemSauce_MenuItems_MenuItemId",
                table: "MenuItemSauce",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemSauce_Sauces_SauceId",
                table: "MenuItemSauce",
                column: "SauceId",
                principalTable: "Sauces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemTopping_MenuItems_MenuItemId",
                table: "MenuItemTopping",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemTopping_Toppings_ToppingId",
                table: "MenuItemTopping",
                column: "ToppingId",
                principalTable: "Toppings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
