using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fist_ASP.NET_Core_Project.Persistence.Abstraction;
using fist_ASP.NET_Core_Project.Persistence;
using System.Text.Json;

namespace fist_ASP.NET_Core_Project
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICountryRepository>(provider => new CountryRepository());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory log,ICountryRepository country)
        {
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/{alpha?}", async context =>
                {
                    var query = context.Request.Query["q"];
                    var listOfCountries = country.AllBy(query).ToList();
                    var json = JsonSerializer.Serialize(listOfCountries);
                    await context.Response.WriteAsync(json);
                });
            });
        }
    }
}
