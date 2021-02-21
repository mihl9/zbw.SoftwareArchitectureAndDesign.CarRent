using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CarRent.Backend.CarManagement.Application;
using CarRent.Backend.CarManagement.Infrastructure;
using CarRent.Backend.Common.Infrastructure.Context;
using CarRent.Backend.Common.Infrastructure.Mapper;
using CarRent.Backend.Common.Interfaces;
using CarRent.Backend.CustomerManagement.Application;
using CarRent.Backend.CustomerManagement.Infrastructure;
using CarRent.Backend.ReservationManagement.Application;
using CarRent.Backend.ReservationManagement.Infrastructure;
using CarRent.Model.CarManagement.Domain;
using CarRent.Model.CustomerManagement.Domain;
using CarRent.Model.ReservationManagement.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace CarRent.Backend
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
            //add the database context
            services.AddDbContext<CarRentDbContext>(config =>
            {
                config.UseNpgsql(Configuration.GetConnectionString("baseConnection"));
            });

            services.AddTransient<ICustomerService, CustomerService>();
            services.AddScoped<IRepository<Customer, Guid>, CustomerRepository>();

            services.AddTransient<IZipCodeService, ZipCodeService>();
            services.AddScoped<IRepository<ZipCode, Guid>, ZipCodeRepository>();

            services.AddTransient<ICarService, CarService>();
            services.AddScoped<IRepository<Car, Guid>, CarRepository>();

            services.AddTransient<ICarClassService, CarClassService>();
            services.AddScoped<IRepository<CarClass, Guid>, CarClassRepository>();

            services.AddTransient<IReservationService, ReservationService>();
            services.AddScoped<IRepository<Reservation, Guid>, ReservationRepository>();

            services.AddAutoMapper(typeof(CarProfile), typeof(CustomerProfile), typeof(ReservationProfile));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarRent.Backend", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarRent.Backend v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
