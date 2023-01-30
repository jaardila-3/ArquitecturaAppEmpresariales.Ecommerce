namespace ArquitecturaAppEmpresariales.Ecommerce.Services.WebApi.Modules.HealthCheck
{
    public static class HealthCheckExtensions
    {
        public static IServiceCollection AddHealthCheckModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddSqlServer(configuration.GetConnectionString("NorthwindConnection"), tags: new[] { "database" })
                //HealthCheack Personalizados
                .AddCheck<HealthCheckCustom>("HealthCheckPersonalizado", tags: new[] { "Personalizado" });

            services.AddHealthChecksUI().AddInMemoryStorage();

            return services;
        }
    }
}
