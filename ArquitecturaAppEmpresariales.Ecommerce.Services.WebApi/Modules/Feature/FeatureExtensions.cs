namespace ArquitecturaAppEmpresariales.Ecommerce.Services.WebApi.Modules.Feature
{
    public static class FeatureExtensions
    {
        public static IServiceCollection AddFeatureModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            var urlAceptadas = configuration.GetSection("AllowedOriginsCORS").Value.Split(",");
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins(urlAceptadas)
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                                  });
            });
            return services;
        }
    }
}
