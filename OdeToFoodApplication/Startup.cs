using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OdeToFood.DataAccess;
using OdeToFood.DataAccess.Repositories;
using OdeToFood.DataAccess.Repositories.Interfaces;

namespace OdeToFoodApplication
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
            services.AddDbContextPool<OdeToFoodDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("OdeToFoodDb"));
            });

            //services.AddSingleton<IRestaurantRepository, InMemoryRestaurantRepository>();

            // Scope to a particular HTTP request.
            services.AddScoped<IRestaurantRepository, SqlRestaurantRepository>();

            #region Fun with service descriptor

            //var serviceDescriptor1 = new ServiceDescriptor(
            //    typeof(IRestaurantRepository),
            //    typeof(SqlRestaurantRepository),
            //    ServiceLifetime.Scoped);

            //var serviceDescriptor2 = ServiceDescriptor.Describe(
            //    typeof(IRestaurantRepository),
            //    typeof(SqlRestaurantRepository),
            //    ServiceLifetime.Scoped);

            //var serviceDescriptor3 = ServiceDescriptor.Scoped(
            //    typeof(IRestaurantRepository),
            //    typeof(SqlRestaurantRepository));

            //var serviceDescriptor4 = ServiceDescriptor.Singleton<IRestaurantRepository, SqlRestaurantRepository>();

            #endregion

            services.AddRazorPages();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
