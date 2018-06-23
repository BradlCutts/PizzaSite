using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PizzaSite.Models.MenuItems;
using PizzaSite.Models.Orders;
using PizzaSite.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Topping> Toppings { set; get; }
        public DbSet<Crust> Crusts { get; set; }
        public DbSet<Cut> Cuts { get; set; }
        public DbSet<Sauce> Sauces { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<MenuItemCut> MenuItemCuts { get; set; }
        public DbSet<MenuItemCrust> MenuItemCrusts { get; set; }
        public DbSet<MenuItemSauce> MenuItemSauces { get; set; }
        public DbSet<MenuItemTopping> MenuItemToppings { get; set; }
        public DbSet<OrderItemTopping> OrderItemToppings { get; set; }
        public DbSet<OrderItemSauce> OrderItemSauces { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItemCrust>()
                .HasKey(mic => new { mic.CrustId, mic.MenuItemId });

            modelBuilder.Entity<MenuItemCrust>()
                .HasOne(mic => mic.MenuItem)
                .WithMany(m => m.MenuItemCrusts)
                .HasForeignKey(mic => mic.MenuItemId);

            modelBuilder.Entity<MenuItemCrust>()
                .HasOne(mic => mic.Crust)
                .WithMany(m => m.MenuItemCrusts)
                .HasForeignKey(mic => mic.CrustId);

            modelBuilder.Entity<MenuItemTopping>()
                .HasKey(mic => new { mic.ToppingId, mic.MenuItemId });

            modelBuilder.Entity<MenuItemTopping>()
                .HasOne(mic => mic.MenuItem)
                .WithMany(m => m.MenuItemToppings)
                .HasForeignKey(mic => mic.MenuItemId);

            modelBuilder.Entity<MenuItemTopping>()
                .HasOne(mic => mic.Topping)
                .WithMany(m => m.MenuItemToppings)
                .HasForeignKey(mic => mic.ToppingId);

            modelBuilder.Entity<MenuItemSauce>()
                .HasKey(mic => new { mic.SauceId, mic.MenuItemId });

            modelBuilder.Entity<MenuItemSauce>()
                .HasOne(mic => mic.MenuItem)
                .WithMany(m => m.MenuItemSauces)
                .HasForeignKey(mic => mic.MenuItemId);

            modelBuilder.Entity<MenuItemSauce>()
                .HasOne(mic => mic.Sauce)
                .WithMany(m => m.MenuItemSauces)
                .HasForeignKey(mic => mic.SauceId);

            modelBuilder.Entity<MenuItemCut>()
                .HasKey(mic => new { mic.CutId, mic.MenuItemId });

            modelBuilder.Entity<MenuItemCut>()
                .HasOne(mic => mic.MenuItem)
                .WithMany(m => m.MenuItemCuts)
                .HasForeignKey(mic => mic.MenuItemId);

            modelBuilder.Entity<MenuItemCut>()
                .HasOne(mic => mic.Cut)
                .WithMany(m => m.MenuItemCuts)
                .HasForeignKey(mic => mic.CutId);

            modelBuilder.Entity<OrderItemTopping>()
                .HasKey(mic => new { mic.ToppingId, mic.OrderItemId });

            modelBuilder.Entity<OrderItemTopping>()
                .HasOne(mic => mic.OrderItem)
                .WithMany(m => m.OrderItemToppings)
                .HasForeignKey(mic => mic.OrderItemId);

            modelBuilder.Entity<OrderItemTopping>()
                .HasOne(mic => mic.Topping)
                .WithMany(m => m.OrderItemToppings)
                .HasForeignKey(mic => mic.ToppingId);

            modelBuilder.Entity<OrderItemSauce>()
                .HasKey(mic => new { mic.SauceId, mic.OrderItemId });

            modelBuilder.Entity<OrderItemSauce>()
                .HasOne(mic => mic.OrderItem)
                .WithMany(m => m.OrderItemSauces)
                .HasForeignKey(mic => mic.OrderItemId);

            modelBuilder.Entity<OrderItemSauce>()
                .HasOne(mic => mic.Sauce)
                .WithMany(m => m.OrderItemSauces)
                .HasForeignKey(mic => mic.SauceId);

            //modelBuilder.Entity<BookCategory>()
            //    .HasKey(bc => new { bc.BookId, bc.CategoryId });

            //modelBuilder.Entity<BookCategory>()
            //    .HasOne(bc => bc.Book)
            //    .WithMany(b => b.BookCategories)
            //    .HasForeignKey(bc => bc.BookId);

            //modelBuilder.Entity<BookCategory>()
            //    .HasOne(bc => bc.Category)
            //    .WithMany(c => c.BookCategories)
            //    .HasForeignKey(bc => bc.CategoryId);
        }
    }
}

