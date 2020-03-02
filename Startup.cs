using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

namespace LunarSports
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940


        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages()
               .AddMvcOptions(options =>
               {
                   options.MaxModelValidationErrors = 50;
                   options.EnableEndpointRouting = false;
                   options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
                       _ => "The field is required.");
               });
            services.AddControllersWithViews();

            var connStr = Configuration.GetConnectionString("DevelopmentConnection");
            services.AddSingleton<IValidationAttributeAdapterProvider,
           ValidationAttributeAdapterProvider>();
            services.AddDbContext<LunarSportsDBContext>(options => options.UseSqlServer(
                connStr
                ));
            // Built in role and user to be inherited, also, the database is specified.
             services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<LunarSportsDBContext>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            //Initalize the user authentacion.
            app.UseAuthentication();
            app.UseStatusCodePages();
            app.UseMvc(routes => routes.MapRoute("default", "{controller=Account}/{action=Register}/{id?}"));


        }
    }
}
