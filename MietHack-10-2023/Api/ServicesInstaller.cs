using Microsoft.Extensions.DependencyInjection;
using MietHack_10_2023.Api.Controllers.Auth;

namespace MjDefaultWithReact.Api
{
    public static class ServicesInstaller
    {
        public static void AddControllerServices(this IServiceCollection services)
        {
            services.AddScoped<AuthService>();
        }
    }
}
