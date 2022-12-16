using ArquitecturaAppEmpresariales.Application.Main;
using ArquitecturaAppEmpresariales.Ecommerce.Application.Interface;
using ArquitecturaAppEmpresariales.Ecommerce.Domain.Core;
using ArquitecturaAppEmpresariales.Ecommerce.Domain.Interface;
using ArquitecturaAppEmpresariales.Ecommerce.Infrastructure.Data;
using ArquitecturaAppEmpresariales.Ecommerce.Infrastructure.Interface;
using ArquitecturaAppEmpresariales.Ecommerce.Infrastructure.Repository;
using ArquitecturaAppEmpresariales.Ecommerce.Services.WebApi.Helpers;
using ArquitecturaAppEmpresariales.Ecommerce.Transversal.Common;
using ArquitecturaAppEmpresariales.Ecommerce.Transversal.Mapper;
using ArquitecturaAppEmpresariales.Ecommerce.Transversal.Logging;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AutoMapper;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
var urlAceptadas = builder.Configuration.GetSection("AllowedOriginsCORS").Value.Split(",");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins(urlAceptadas)
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

//Auto Mapper Configurations
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingsProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

//DI
builder.Services.AddSingleton<IConnectionFactory, ConnectionFactory>();
builder.Services.AddScoped<ICustomerApplication, CustomerApplication>();
builder.Services.AddScoped<ICustomersDomain, CustomersDomain>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IUsersApplication, UsersApplication>();
builder.Services.AddScoped<IUsersDomain, UsersDomain>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>)); // son genéricas

//JWT
var appSettingsSection = builder.Configuration.GetSection("Config");
builder.Services.Configure<AppSettings>(appSettingsSection);
//configure JWT
var appsettings = appSettingsSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appsettings.Secret);
var Issuer = appsettings.Issuer;
var Audience = appsettings.Audience;

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(x =>
        {
            x.Events = new JwtBearerEvents
            {
                OnTokenValidated = context =>
                {
                    //recupera los datos de los claims que vienen en context.Principal
                    var userId = int.Parse(context!.Principal!.Identity!.Name);
                    return Task.CompletedTask;
                },
                OnAuthenticationFailed = context =>
                {
                    if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                    {
                        context.Response.Headers.Add("Token-Expired", "true");
                    }
                    return Task.CompletedTask;
                }
            };
            x.RequireHttpsMetadata = false;
            x.SaveToken = false; //propiedad que define si el token debe almacenarse en AuthenticationProperties después de una autorización exitosa
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = Issuer,
                ValidateAudience = true,
                ValidAudience = Audience,
                ValidateLifetime = true, //valida tiempo de vida del token
                ClockSkew = TimeSpan.Zero //diferencia entre horas
            };
        });

//swagger generator: https://learn.microsoft.com/es-es/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-6.0
builder.Services.AddSwaggerGen(options =>
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
    //input para el token
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Encabezado de autorización JWT utilizando el esquema Bearer."
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                                    {
                                        {
                                              new OpenApiSecurityScheme
                                              {
                                                  Reference = new OpenApiReference
                                                  {
                                                      Type = ReferenceType.SecurityScheme,
                                                      Id = "Bearer"
                                                  }
                                              },
                                             new List<string>()
                                        }
                                    });
});

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
