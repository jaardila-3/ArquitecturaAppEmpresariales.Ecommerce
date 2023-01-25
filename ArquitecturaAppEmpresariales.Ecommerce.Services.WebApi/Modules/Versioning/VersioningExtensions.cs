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
                //Control de Versiones utilizando Parámetros de Cadena de Consulta (Query String): # de version como parámetro en la url
                //options.ApiVersionReader = new QueryStringApiVersionReader("api-version");
                //Control de Versiones Utilizando Encabezados Personalizados (Header)
                //options.ApiVersionReader = new HeaderApiVersionReader("x-version");
                //Control de Versiones utilizando Parámetros en el Segmento de la URL
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                //Control de Versiones utilizando Parámetros en el Segmento de la URL: indica que se reemplaza un segmento de la url por la version de la api
                options.SubstituteApiVersionInUrl = true;
            });

            return services;
        }
    }
}
