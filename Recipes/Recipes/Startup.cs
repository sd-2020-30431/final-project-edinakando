using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Recipes.BusinessLogic;
using Recipes.BusinessLogic.Logic;
using Recipes.DataAccess;
using Recipes.DataAccess.Repositories;

namespace Recipes
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();

            services.AddTransient<UserLogic>();
            services.AddTransient<RecipesLogic>();
            services.AddTransient<UserRepository>();
            services.AddTransient<RoleRepository>();
            services.AddTransient<RecipesRepository>();

            services.AddDbContext<RecipesDbContext>(options => options.UseMySql(Configuration.GetConnectionString("RECIPES_DB")));
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
