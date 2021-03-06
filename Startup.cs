﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AroudYou.Persistence;
using Microsoft.EntityFrameworkCore;
using AroudYou.Core;
using Microsoft.AspNetCore.Http;
using AroudYou.Services;
using AroudYou.Middlewares;

namespace AroudYou
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

            services.AddDbContext<AroundContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISeedDataService, SeedDataService>();

            //services.AddDbContext<AroundContext>(options => options.UseSqlServer(Configuration.GetConnectionString("office")));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSeedDataMiddleware();

            app.UseMvc();


            //app.Use(async (context, next) =>
            //{
            //    // Do work that doesn't write to the Response.
            //    await next.Invoke();
            //    // Do logging or other work that doesn't write to the Response.
            //});

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello from 2nd delegate.");
            //});

        }
    }
}
