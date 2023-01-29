using ArquitecturaAppEmpresariales.Ecommerce.Services.WebApi.Modules.Authentication;
using ArquitecturaAppEmpresariales.Ecommerce.Services.WebApi.Modules.Feature;
using ArquitecturaAppEmpresariales.Ecommerce.Services.WebApi.Modules.HealthCheck;
using ArquitecturaAppEmpresariales.Ecommerce.Services.WebApi.Modules.Injection;
using ArquitecturaAppEmpresariales.Ecommerce.Services.WebApi.Modules.Mapper;
using ArquitecturaAppEmpresariales.Ecommerce.Services.WebApi.Modules.Swagger;
using ArquitecturaAppEmpresariales.Ecommerce.Services.WebApi.Modules.Validator;
using ArquitecturaAppEmpresariales.Ecommerce.Services.WebApi.Modules.Versioning;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
#region Módulos de servicios, métodos de extensión
//CORS
builder.Services.AddFeatureModule(builder.Configuration);
//Auto Mapper Configurations
builder.Services.AddMapperModule();
//DI
builder.Services.AddInjectionModule();
//JWT
builder.Services.AddAuthenticationModule(builder.Configuration);
//versioning
builder.Services.AddVersioningModule();
//swagger
builder.Services.AddSwaggerModule();
//fluent validator
builder.Services.AddValidatorModule();
//Health Check
builder.Services.AddHealthCheckModule(builder.Configuration);
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        // build a swagger endpoint for each discovered API version
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
            //options.RoutePrefix = string.Empty;
        }
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
//Health Check
app.MapHealthChecksUI();
app.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();
