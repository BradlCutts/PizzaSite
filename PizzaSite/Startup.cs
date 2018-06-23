using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaSite.Models;
using PizzaSite.Models.Crusts;
using PizzaSite.Models.Cuts;
using PizzaSite.Models.Orders;
using PizzaSite.Models.Sauces;
using PizzaSite.Models.Toppings;
using PizzaSite.Models.Users;

namespace PizzaSite
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

            services.AddTransient<IMenuItemRepository, MenuItemRepository>();
            services.AddTransient<ICrustRepository, CrustRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderItemRepository, OrderItemRepository>(); 
            services.AddTransient<ICutRepository, CutRepository>();
            services.AddTransient<ISauceRepository, SauceRepository>();
            services.AddTransient<IToppingRepository, ToppingRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            
            services.AddMvc();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", p => p.RequireAuthenticatedUser().RequireRole("admin"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}"
                    );
                routes.MapRoute(
                    name: "TwoIds",
                    template: "{controller}/{acti on}/{id1}/{id2}"
                    );
                //routes.MapRoute can get called many times with different routes 
                //for larger applications.
            }
           );
        }
    }
}
