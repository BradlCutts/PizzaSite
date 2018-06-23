using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models
{
    public static class DbInitializer
    { public static void Seed(AppDbContext context)
        {
            if(!context.Crusts.Any())
            {
                context.AddRange
                    (
                        new Crust { Title = "Deep-dish", Price = 2.00M, Description = "Our delectable Deep-dish!" },
                        new Crust { Title = "New York Style", Price = 0.00M, Description = "Classic New York Style." },
                        new Crust { Title = "Thin", Price = 1.00M, Description = "Thin and Crunchy!" }

                    );
            }
            if (!context.Cuts.Any())
            {
                context.AddRange
                    (
                        new Cut { Title ="Classic", Price = 0.00M, Description = "Our Classic Pie Cut"},
                        new Cut { Title = "Square", Price = 0.50M, Description = "Nice and stright!"}
                    );
            }
            if (!context.Sauces.Any())
            {
                context.AddRange
                    (
                        new Sauce { Title = "Red", Price = 0.00M, Description = "Traditional red marinara." },
                        new Sauce { Title = "White", Price = 0.50M, Description = "White sauce is the boss!" }
                    );
            }
            if (!context.Toppings.Any())
            {
                context.AddRange
                    (
                        new Topping { Title = "Pepperoni", Price = 0.50M, Description = "Pepperoni" },
                        new Topping { Title = "Sausage", Price = 0.50M, Description = "Sausage" },
                        new Topping { Title = "Ham", Price = 0.50M, Description = "Ham"}
                    );
            }

            if(!context.MenuItems.Any())
            {
                context.AddRange
                   (
                new MenuItem { Title = "Custom Creation", ShortDescription = "Create your own Pizza, just the way you like it!", LongDescription = "Create your own Pizza, just the way you like it!", ImageUrl = "https://www.papajohns.com/static-assets/a/images/web/marketing-item/create-your-own-panel-compressed.jpg", ThumbnailUrl = "https://www.papajohns.com/static-assets/a/images/web/marketing-item/create-your-own-panel-compressed.jpg", Type = "Pizza" },
                new MenuItem { Title = "Pepperoni", ShortDescription = "Classic pepperoni pizza with mozarella cheese and regular crust.", LongDescription = "Classic pepperoni pizza with mozarella cheese and regular crust.", ImageUrl = "https://cdn0.tnwcdn.com/wp-content/blogs.dir/1/files/2016/06/shutterstock_225746563-796x531.jpg", ThumbnailUrl = "https://cdn0.tnwcdn.com/wp-content/blogs.dir/1/files/2016/06/shutterstock_225746563-796x531.jpg", Type = "Pizza" },
                new MenuItem { Title = "Sausage", ShortDescription = "Classic cheese pizza topped with authentic italian sausage.", LongDescription = "Classic cheese pizza topped with authentic italian sausage.", ImageUrl = "https://cdn.schwans.com/media/images/products/56721-1-1540.jpg", ThumbnailUrl = "https://cdn.schwans.com/media/images/products/56721-1-1540.jpg", Type = "Pizza" }
                );
            }
            if(!context.MenuItemCuts.Any())
            {
                context.AddRange(
                    
                    );
            }

            context.SaveChanges();

        }
    }
}
