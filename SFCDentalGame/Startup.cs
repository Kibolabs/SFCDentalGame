using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SFCDentalGame.DAL.Interfaces;
using SFCDentalGame.DAL;
using Microsoft.EntityFrameworkCore;
using SFCDentalGame.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using SFCDentalGame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace SFCDentalGame
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<SFCContext>(options =>
            options.UseSqlite("Data Source=SylvanDentalGameDb.db"));

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<SFCContext>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp=>DentalPractice.GetPractice(sp));

            services.AddMvc();

            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseSession();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "Admini",
                    template: "controller=Behaviour/{action}/{id?}",
                    defaults: new {Controller="Behaviour", action="Index"});
        
                routes.MapRoute(name:"Category Filter", template:"Behaviour/{action}/{category}",
                                defaults: new {Controller="Behaviour", action="List"});
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
