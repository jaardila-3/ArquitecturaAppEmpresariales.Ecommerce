using ArquitecturaAppEmpresariales.Ecommerce.Services.WebApi.Modules.Authentication;
using ArquitecturaAppEmpresariales.Ecommerce.Services.WebApi.Modules.Feature;
using ArquitecturaAppEmpresariales.Ecommerce.Services.WebApi.Modules.Injection;
using ArquitecturaAppEmpresariales.Ecommerce.Services.WebApi.Modules.Mapper;
using ArquitecturaAppEmpresariales.Ecommerce.Services.WebApi.Modules.Swagger;

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
//swagger
builder.Services.AddSwaggerModule();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API Ecommerce v1");
        //options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
