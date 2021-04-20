using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Custom_MiddleWareDemo.MiddleWare
{
    public class CustomLogger
    {
        private RequestDelegate _next;

        public CustomLogger(RequestDelegate next)
        {
            _next = next; 
        }

        public Task Invoke(HttpContext context)
        {
            if (context.Request.Query.ContainsKey("id"))
            {
                var id = context.Request.Query["id"];
                Console.WriteLine($"Product with id:{id}");
            }
            return _next(context);
        }
    }

    public static class CustomLoggerExtension
    {
        public static IApplicationBuilder UseCustomLogger(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomLogger>();
        }
    }
}
