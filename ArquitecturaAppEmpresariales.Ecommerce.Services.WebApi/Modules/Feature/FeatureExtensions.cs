namespace ArquitecturaAppEmpresariales.Ecommerce.Services.WebApi.Modules.Feature
{
    public static class FeatureExtensions
    {
        public static IServiceCollection AddFeatureModule(this IServiceCollection services, IConfiguration configuration)
        {
            string myPolicy = "policyApiEcommerce";
            var urlAceptadas = configuration.GetSection("AllowedOriginsCORS").Value.Split(",");
            services.AddCors(options =>
            {
                options.AddPolicy(name: myPolicy,
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
