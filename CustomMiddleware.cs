using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Platform
{
    public class CustomMiddleware
    {
        private RequestDelegate _next;
        public CustomMiddleware()
        {
            
        }

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "true")
            {
                await context.Response.WriteAsync("Class-based middlware \n");
            }
            if (_next != null)
            {
                await _next(context);
            }
        }
    }
}
