using Azure.Storage.Blobs;
using GunDetection.Data;
using GunDetection.Data.Data;
using GunDetection.Data.Interface;
using GunDetection.Data.Services;
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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GunDetection.Api
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


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GunDetection.Api", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddDbContext<GunDbContext>(

                 options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionMain")));

            services.AddScoped(x => new BlobServiceClient(Configuration.GetValue<string>("AzureBlobStorage")));
            services.AddScoped<IBlobStorageAzure, BlobStorageAzure>();

            services.AddScoped<IUserData, UserData>();
            services.AddScoped<ILocationData, LocationData>();
            services.AddScoped<ICameraData, CameraData>();
            services.AddScoped<ISubUserData, SubUserData>();
            services.AddScoped<IAlertData, AlertData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GunDetection.Api v1"));
            }
            
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GunDetection.Api v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

           // app.UseCors(opt => opt.WithOrigins("http://localhost:4200")
           //          .AllowAnyHeader().AllowAnyMethod().AllowCredentials()
           //);


            app.UseCors(builder => builder.
            AllowAnyOrigin().
            AllowAnyHeader().
            AllowAnyMethod()
            //.AllowCredentials()
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
