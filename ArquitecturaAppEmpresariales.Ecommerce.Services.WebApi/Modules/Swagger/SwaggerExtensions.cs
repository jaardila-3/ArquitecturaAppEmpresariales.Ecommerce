using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace ArquitecturaAppEmpresariales.Ecommerce.Services.WebApi.Modules.Swagger
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerModule(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //swagger generator: https://learn.microsoft.com/es-es/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-6.0
            return services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
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
                });
                //add XML in .csproj
                // using System.Reflection;
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                options.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securityScheme, new List<string>() { } }
                });                
            });

        }
    }
}
