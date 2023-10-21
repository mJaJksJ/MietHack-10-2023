using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Startup.Middlewares.HttpResponseMiddleware
{
    internal class HttpResponseMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        /// <summary>
        /// .ctor
        /// </summary>
        public HttpResponseMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// Выполнить миддлвар
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var ruEx = ex as RussianException ;
                context.Response.StatusCode = ruEx?.StatusCode ?? StatusCodes.Status500InternalServerError;
                _logger.Error(ex, ex.Message);
                await context.Response.WriteAsJsonAsync(ruEx?.Message ?? "Internal server error");
            }
        }
    }
}
