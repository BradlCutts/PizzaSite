using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PizzaSite.Migrations
{
    public partial class abc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crusts_MenuItems_MenuItemId",
                table: "Crusts");

            migrationBuilder.DropForeignKey(
                name: "FK_Crusts_OrderItems_OrderItemId",
                table: "Crusts");

            migrationBuilder.DropForeignKey(
                name: "FK_Cuts_MenuItems_MenuItemId",
                table: "Cuts");

            migrationBuilder.DropForeignKey(
                name: "FK_Cuts_OrderItems_OrderItemId",
                table: "Cuts");

            migrationBuilder.DropForeignKey(
                name: "FK_Sauces_MenuItems_MenuItemId",
                table: "Sauces");

            migrationBuilder.DropForeignKey(
                name: "FK_Sauces_OrderItems_OrderItemId",
                table: "Sauces");

            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_MenuItems_MenuItemId",
                table: "Toppings");

            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_OrderItems_OrderItemId",
                table: "Toppings");

            migrationBuilder.DropIndex(
                name: "IX_Toppings_MenuItemId",
                table: "Toppings");

            migrationBuilder.DropIndex(
                name: "IX_Toppings_OrderItemId",
                table: "Toppings");

            migrationBuilder.DropIndex(
                name: "IX_Sauces_MenuItemId",
                table: "Sauces");

            migrationBuilder.DropIndex(
                name: "IX_Sauces_OrderItemId",
                table: "Sauces");

            migrationBuilder.DropIndex(
                name: "IX_Cuts_MenuItemId",
                table: "Cuts");

            migrationBuilder.DropIndex(
                name: "IX_Cuts_OrderItemId",
                table: "Cuts");

            migrationBuilder.DropIndex(
                name: "IX_Crusts_MenuItemId",
                table: "Crusts");

            migrationBuilder.DropIndex(
                name: "IX_Crusts_OrderItemId",
                table: "Crusts");

            migrationBuilder.DropColumn(
                name: "MenuItemId",
                table: "Toppings");

            migrationBuilder.DropColumn(
                name: "OrderItemId",
                table: "Toppings");

            migrationBuilder.DropColumn(
                name: "MenuItemId",
                table: "Sauces");

            migrationBuilder.DropColumn(
                name: "OrderItemId",
                table: "Sauces");

            migrationBuilder.DropColumn(
                name: "MenuItemId",
                table: "Cuts");

            migrationBuilder.DropColumn(
                name: "OrderItemId",
                table: "Cuts");

            migrationBuilder.DropColumn(
                name: "MenuItemId",
                table: "Crusts");

            migrationBuilder.DropColumn(
                name: "OrderItemId",
                table: "Crusts");

            migrationBuilder.AddColumn<int>(
                name: "CrustId",
                table: "OrderItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CutId",
                table: "OrderItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "OrderItems",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MenuItemCrust",
                columns: table => new
                {
                    CrustId = table.Column<int>(nullable: false),
                    MenuItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemCrust", x => new { x.CrustId, x.MenuItemId });
                    table.ForeignKey(
                        name: "FK_MenuItemCrust_Crusts_CrustId",
                        column: x => x.CrustId,
                        principalTable: "Crusts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItemCrust_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItemCut",
                columns: table => new
                {
                    CutId = table.Column<int>(nullable: false),
                    MenuItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemCut", x => new { x.CutId, x.MenuItemId });
                    table.ForeignKey(
                        name: "FK_MenuItemCut_Cuts_CutId",
                        column: x => x.CutId,
                        principalTable: "Cuts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItemCut_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItemSauce",
                columns: table => new
                {
                    SauceId = table.Column<int>(nullable: false),
                    MenuItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemSauce", x => new { x.SauceId, x.MenuItemId });
                    table.ForeignKey(
                        name: "FK_MenuItemSauce_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItemSauce_Sauces_SauceId",
                        column: x => x.SauceId,
                        principalTable: "Sauces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItemTopping",
                columns: table => new
                {
                    ToppingId = table.Column<int>(nullable: false),
                    MenuItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemTopping", x => new { x.ToppingId, x.MenuItemId });
                    table.ForeignKey(
                        name: "FK_MenuItemTopping_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItemTopping_Toppings_ToppingId",
                        column: x => x.ToppingId,
                        principalTable: "Toppings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItemSauce",
                columns: table => new
                {
                    SauceId = table.Column<int>(nullable: false),
                    OrderItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemSauce", x => new { x.SauceId, x.OrderItemId });
                    table.ForeignKey(
                        name: "FK_OrderItemSauce_OrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItemSauce_Sauces_SauceId",
                        column: x => x.SauceId,
                        principalTable: "Sauces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItemTopping",
                columns: table => new
                {
                    ToppingId = table.Column<int>(nullable: false),
                    OrderItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemTopping", x => new { x.ToppingId, x.OrderItemId });
                    table.ForeignKey(
                        name: "FK_OrderItemTopping_OrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItemTopping_Toppings_ToppingId",
                        column: x => x.ToppingId,
                        principalTable: "Toppings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_CrustId",
                table: "OrderItems",
                column: "CrustId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_CutId",
                table: "OrderItems",
                column: "CutId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_SizeId",
                table: "OrderItems",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemCrust_MenuItemId",
                table: "MenuItemCrust",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemCut_MenuItemId",
                table: "MenuItemCut",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemSauce_MenuItemId",
                table: "MenuItemSauce",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemTopping_MenuItemId",
                table: "MenuItemTopping",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemSauce_OrderItemId",
                table: "OrderItemSauce",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemTopping_OrderItemId",
                table: "OrderItemTopping",
                column: "OrderItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Crusts_CrustId",
                table: "OrderItems",
                column: "CrustId",
                principalTable: "Crusts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Cuts_CutId",
                table: "OrderItems",
                column: "CutId",
                principalTable: "Cuts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Sizes_SizeId",
                table: "OrderItems",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Crusts_CrustId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Cuts_CutId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Sizes_SizeId",
                table: "OrderItems");

            migrationBuilder.DropTable(
                name: "MenuItemCrust");

            migrationBuilder.DropTable(
                name: "MenuItemCut");

            migrationBuilder.DropTable(
                name: "MenuItemSauce");

            migrationBuilder.DropTable(
                name: "MenuItemTopping");

            migrationBuilder.DropTable(
                name: "OrderItemSauce");

            migrationBuilder.DropTable(
                name: "OrderItemTopping");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_CrustId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_CutId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_SizeId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "CrustId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "CutId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "OrderItems");

            migrationBuilder.AddColumn<int>(
                name: "MenuItemId",
                table: "Toppings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderItemId",
                table: "Toppings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuItemId",
                table: "Sauces",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderItemId",
                table: "Sauces",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuItemId",
                table: "Cuts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderItemId",
                table: "Cuts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuItemId",
                table: "Crusts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderItemId",
                table: "Crusts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Toppings_MenuItemId",
                table: "Toppings",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Toppings_OrderItemId",
                table: "Toppings",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Sauces_MenuItemId",
                table: "Sauces",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Sauces_OrderItemId",
                table: "Sauces",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuts_MenuItemId",
                table: "Cuts",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuts_OrderItemId",
                table: "Cuts",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Crusts_MenuItemId",
                table: "Crusts",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Crusts_OrderItemId",
                table: "Crusts",
                column: "OrderItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Crusts_MenuItems_MenuItemId",
                table: "Crusts",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Crusts_OrderItems_OrderItemId",
                table: "Crusts",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cuts_MenuItems_MenuItemId",
                table: "Cuts",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cuts_OrderItems_OrderItemId",
                table: "Cuts",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sauces_MenuItems_MenuItemId",
                table: "Sauces",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sauces_OrderItems_OrderItemId",
                table: "Sauces",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Toppings_MenuItems_MenuItemId",
                table: "Toppings",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Toppings_OrderItems_OrderItemId",
                table: "Toppings",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
