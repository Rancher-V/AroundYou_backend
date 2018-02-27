using AroudYou.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AroudYou.Middlewares
{
    public class SeedDataMiddleware
    {
        private readonly RequestDelegate _next;

        public SeedDataMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ISeedDataService seedDataService)
        {
            await seedDataService.EnsureSeedData();
            await _next.Invoke(context);
            

        }


    }
}
