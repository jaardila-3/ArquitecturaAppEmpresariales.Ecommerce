using ArquitecturaAppEmpresariales.Ecommerce.Services.WebApi.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ArquitecturaAppEmpresariales.Ecommerce.Services.WebApi.Modules.Authentication
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddAuthenticationModule(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("Config");
            services.Configure<AppSettings>(appSettingsSection);
            //configure JWT
            var appsettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appsettings.Secret);
            var Issuer = appsettings.Issuer;
            var Audience = appsettings.Audience;

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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

            return services;
        }
    }
}
