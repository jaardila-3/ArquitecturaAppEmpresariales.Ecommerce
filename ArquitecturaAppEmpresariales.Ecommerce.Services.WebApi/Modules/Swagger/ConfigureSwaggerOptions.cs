using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ArquitecturaAppEmpresariales.Ecommerce.Services.WebApi.Modules.Swagger
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider provider;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ConfigureSwaggerOptions"/> 
        /// </summary>
        /// <param name="provider">El <see cref="IApiVersionDescriptionProvider">proveedor</see>
        /// usado para generar documentación swagger con el versionamiento </param>
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;

        /// <inheritdoc/>
        public void Configure(SwaggerGenOptions options)
        {
            //agregar un documento de swagger para cada versión de API detectada
            //Nota: puede optar por omitir o documentar versiones de API obsoletas de forma diferente
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Version = description.ApiVersion.ToString(),
                Title = "Curso de arquitecturas empresariales",
                Description = "API Ecommerce del curso Arquitectura de Aplicaciones Empresariales con .NET Core de Udemy, con el instructor Alex Espejo",
                TermsOfService = new Uri("https://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Jorge Ardila",
                    Email = "jorge.ardila1641@correo.policia.gov.co",
                    Url = new Uri("https://example.com/contact")
                },
                License = new OpenApiLicense
                {
                    Name = "Usar bajo licencia",
                    Url = new Uri("https://example.com/license")
                }
            };

            return info;
        }
    }
}
