using Microsoft.AspNetCore.Builder;
using Serilog;

namespace Startup.Middlewares.HttpResponseMiddleware
{
    public static class HttpResponseMiddlewareExtensions
    {
        public static IApplicationBuilder UseHttpResponseMiddleware(this IApplicationBuilder app, ILogger logger)
        {
            return app.UseMiddleware<HttpResponseMiddleware>(logger);
        }
    }
}
