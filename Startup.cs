using System;
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
            services.AddDbContext<AroundContext>(options => options.UseSqlServer(Configuration.GetConnectionString("office")));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                // ref: https://github.com/threenine/swcApi/blob/master/src/Api/Startup.cs
                //if (!serviceScope.ServiceProvider.GetService<ApiContext>().AllMigrationsApplied())
                //{
                //    serviceScope.ServiceProvider.GetService<ApiContext>().Database.Migrate();
                //    serviceScope.ServiceProvider.GetService<ApiContext>().EnsureSeeded();
                //}

                var context = serviceScope.ServiceProvider.GetService<AroundContext>();
                //context.Database.Migrate();
                context.EnsureSeedData();

            }

        }
    }
}
