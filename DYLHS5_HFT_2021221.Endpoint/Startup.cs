using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DYLHS5_HFT_2021221.Logic;
using DYLHS5_HFT_2021221.Data;
using DYLHS5_HFT_2021221.Repository;

namespace DYLHS5_HFT_2021221.Endpoint
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
            //services.AddRazorPages();
            services.AddControllers();

            //Handling the dependency injections
            services.AddTransient<IOrderLogic, OrderLogic>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddTransient<ICustomerLogic, CustomerLogic>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();

            services.AddTransient<IProductLogic, ProductLogic>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<XYZDbContext, XYZDbContext>();
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

            //app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
