using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MietHack_10_2023.Database;
using MjDefaultWithReact.Api;
using Serilog;
using Startup;
using Startup.AuthSettings;
using Startup.DatabaseSettings;
using Startup.LogSettings;
using Startup.Middlewares.HttpResponseMiddleware;
using Startup.SwaggerSettings;
using System.Linq;

namespace MietHack_10_2023
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Paths.Init("MietHack_10_2023");
            var builder = WebApplication.CreateBuilder(args);

            builder.AddSerilog();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddMjAuthentification(builder.Configuration);
            builder.Services.AddMjAuthorization();

            builder.Services.AddDatabaseService<DatabaseContext>(builder.Configuration);
            builder.Services.AddControllerServices();
            builder.Services.AddSwaggerService("v0");

            //builder.Services.AddControllerServices();

            var app = builder.Build();

            var log = Log.ForContext<Program>();
            app.UseHttpResponseMiddleware(log);

            app.UseDatabase<DatabaseContext>();

            app.UseSwaggerMiddleware();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(x => { x.MapControllers(); });
            
            app.Run();
        }
    }
}