using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rozetka;
using ProductsAnalysisWeb.Data;
namespace ProductsAnalysisWeb
{
    public class Startup
    {
        private  IConfiguration _config { get; }

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
  
            services.AddRazorPages();
            services.AddMvc();
            services.AddControllersWithViews();

            services.AddDbContext<DB>(options =>
                    options.UseSqlServer(_config.GetConnectionString("DB")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Fallback", "{controller}/{action}/{id?}",
                    new { controller = "App", action = "Home" });

                endpoints.MapRazorPages();  
            });
        }
    }
}
