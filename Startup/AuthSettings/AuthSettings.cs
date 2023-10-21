using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Startup.Configuration;
using System;
using System.Threading.Tasks;

namespace Startup.AuthSettings
{
    public static class AuthSettings
    {
        public static void AddMjAuthentification(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var authConfig = configuration.GetSection(AuthConfig.ConfigName).Get<AuthConfig>();

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(authConfig.JwtSecurityKey),

                        ValidateIssuer = true,
                        ValidIssuer = authConfig.JwtIssuer,

                        ValidateAudience = true,
                        ValidAudience = authConfig.JwtAudience,

                        RequireExpirationTime = true,
                        ValidateLifetime = true,

                        ClockSkew = TimeSpan.FromMinutes(1)
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = _ =>
                        {
                            if (string.IsNullOrEmpty(_.Token))
                            {
                                var fromAuth = _.Request.Query["auth"];
                                if (!string.IsNullOrEmpty(fromAuth)) _.Token = fromAuth;

                                var fromAccessToken = _.Request.Query["access_token"];
                                if (!string.IsNullOrEmpty(fromAccessToken)) _.Token = fromAccessToken;
                            }

                            return Task.CompletedTask;
                        }
                    };
                });
        }

        public static void AddMjAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(
                options =>
                {
                    options.DefaultPolicy = new AuthorizationPolicyBuilder()
                        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                        .RequireAuthenticatedUser()
                        .Build();
                });
        }
    }
}
