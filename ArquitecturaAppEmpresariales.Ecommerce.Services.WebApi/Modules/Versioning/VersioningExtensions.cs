using Microsoft.AspNetCore.Mvc.Versioning;

namespace ArquitecturaAppEmpresariales.Ecommerce.Services.WebApi.Modules.Versioning
{
    public static class VersioningExtensions
    {
        public static IServiceCollection AddVersioningModule(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = new QueryStringApiVersionReader("api-version");
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                //options.SubstituteApiVersionInUrl = true;
            });

            return services;
        }
    }
}
