using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Platform
{
    public class LocationMiddleware
    {
        private RequestDelegate _next;
        private MessageOptions _options;
        public LocationMiddleware(RequestDelegate next, IOptions<MessageOptions> options)
        {
            _next = next;
            _options = options.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/location")
            {
                await context.Response.WriteAsync($"{_options.CityName}, {_options.CountryName}");
            }
            else
            {
                await _next(context);
            }
        }
    }
}
