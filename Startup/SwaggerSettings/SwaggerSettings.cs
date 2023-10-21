using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Startup.SwaggerSettings
{
    public static class SwaggerSettings
    {
        private static string Version { get; set; }

        public static void AddSwaggerService(this IServiceCollection services, string version)
        {
            Version = version;
            services.AddSwaggerGenNewtonsoftSupport();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(version, new OpenApiInfo
                {
                    Title = Paths.AppName,
                    Version = version
                });

                c.IncludeXmlComments(Paths.DocsFile);
                c.SchemaFilter<EnumTypesSchemaFilter>(Paths.DocsFile);
                c.DocumentFilter<EnumTypesDocumentFilter>();
                c.CustomOperationIds(e => (e.ActionDescriptor as ControllerActionDescriptor)?.ActionName);
            });
        }

        public static void UseSwaggerMiddleware(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint($"/swagger/{Version}/swagger.json", Paths.AppName); });
        }
    }
}
