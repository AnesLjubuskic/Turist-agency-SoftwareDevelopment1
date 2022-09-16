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
using RS1Seminarski.Data;
using RS1Seminarski.Hubs;
using RS1Seminarski.Modul_Smjestaj.Email;
using RS1Seminarski.Modul_Smjestaj.Services.FileService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RS1Seminarski
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));


            services.AddControllers();
            services.AddSignalR().AddMessagePackProtocol();


            // services.AddSignalR();


            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddScoped<IEmail, Email>();
            services.AddScoped<IFileService, FileService>();
            //services.AddScoped<INotifications, Notification>();
            services.AddSwaggerGen();


            services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseHttpsRedirection();
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "RS1Seminarski v1");
            });



            app.UseCors(
               options => options
               .SetIsOriginAllowed(x => _ = true)
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials()
           ); //This needs to set everything allowed


            app.UseRouting();


            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapHub<ChatHub>("/signalr");

            });


            //app.UseEndpoints(endpoints=>
            //{
            //    endpoints.MapHub<BroadcastHub>("/notify");
            //});

           
        }
    }



    //public class Startup
    //{
    //    public Startup(IConfiguration configuration)
    //    {
    //        Configuration = configuration;
    //    }

    //    public IConfiguration Configuration { get; }

    //    // This method gets called by the runtime. Use this method to add services to the container.

    //    public void ConfigureServices(IServiceCollection services)
    //    {
    //        services.AddDbContext<ApplicationDbContext>(options =>
    //           options.UseSqlServer(
    //               Configuration.GetConnectionString("DefaultConnection")));

    //        services.AddControllers();
    //        services.AddSwaggerGen(c =>
    //        {
    //            c.SwaggerDoc("v1", new OpenApiInfo { Title = "RS1Seminarski", Version = "v1" });
    //        });
    //    }

    //    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    //    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    //    {
    //        if (env.IsDevelopment())
    //        {
    //            //app.UseDeveloperExceptionPage();
    //            //app.UseSwagger();
    //            //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RS1Seminarski v1"));
    //            app.UseDeveloperExceptionPage();
    //            app.UseDatabaseErrorPage();
    //        }
    //        else
    //        {
    //            app.UseExceptionHandler("/Error");
    //            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //            app.UseHsts();
    //        }

    //        app.UseDefaultFiles();
    //        app.UseStaticFiles();

    //        app.UseHttpsRedirection();
    //        app.UseSwagger();



    //        app.UseSwaggerUI(c =>
    //        {
    //            c.SwaggerEndpoint("/swagger/v1/swagger.json", "RS1Seminarski v1");
    //         });

    //        app.UseCors(
    //          options => options
    //          .SetIsOriginAllowed(x => _ = true)
    //          .AllowAnyMethod()
    //          .AllowAnyHeader()
    //          .AllowCredentials()
    //      ); //This needs to set everything allowed

    //        //app.UseHttpsRedirection();


    //        //app.UseAuthorization();

    //        //app.UseEndpoints(endpoints =>
    //        //{
    //        //    endpoints.MapControllers();
    //        //});

    //        app.UseRouting();
    //        app.UseEndpoints(endpoints =>
    //        {
    //            endpoints.MapControllerRoute(
    //                name: "default",
    //                pattern: "{controller}/{action=Index}/{id?}");
    //        });
    //    }
    //}


}
