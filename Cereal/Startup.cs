﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Cereal.Data;
using Microsoft.AspNetCore.Identity;
using Cereal.Models;
using Cereal.Models.Interfaces;
using Cereal.Models.Services;
using Cereal.Models.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Cereal
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup()
        {
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<CerealDBContext>(options =>
            options.UseSqlServer(Configuration["ConnectionStrings:ProductionDb"])
            );

            //services.AddDbContext<CerealDBContext>(options =>
            //options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"])
            //);

            services.AddTransient<IProduct,ProductService>();
            services.AddTransient<IBasketItems, BasketItemsService>();

            services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlServer(Configuration["ConnectionStrings:ProductionIdentityConnection"])
           );
            //services.AddDbContext<ApplicationDbContext>(options =>
            //options.UseSqlServer(Configuration["ConnectionStrings:IdentityConnection"])
            //);

            //implementation for policies
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole
                (UserRoles.Admin));
                options.AddPolicy("EmailPolicy", policy => policy.Requirements.Add(new EmployeeEmailRequirement()));
            });

            services.AddScoped<IAuthorizationHandler, EmployeeEmailRequirement>();
            services.AddScoped<IEmailSender, EmailSender>();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}