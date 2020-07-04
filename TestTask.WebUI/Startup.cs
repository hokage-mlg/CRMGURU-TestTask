using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using TestTask.Domain.Abstract;
using TestTask.Domain.Concrete;

namespace TestTask.WebUI
{
    public class Startup
    {
        /// <summary>
        /// Ñonstructor for startup class
        /// </summary>
        /// <param name="configuration"> Interface of configuration </param>
        public Startup(IConfiguration configuration) => Configuration = configuration;
        /// <summary>
        /// Interface of configuration
        /// </summary>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"> Interface of service collection </param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Use default connection
            string connection = Configuration.GetConnectionString("DefaultConnection");
            // Dependency Injection
            services.AddTransient<ICityRepository, CityRepository>(provider => new CityRepository(connection));
            services.AddTransient<ICountryRepository, CountryRepository>(provider => new CountryRepository(connection));
            services.AddTransient<IRegionRepository, RegionRepository>(provider => new RegionRepository(connection));
            services.AddControllersWithViews();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days.
                app.UseHsts();
            }
            app.UseRequestLocalization();
            var cultureInfo = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
