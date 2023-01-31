using WatchDog;

namespace ArquitecturaAppEmpresariales.Ecommerce.Services.WebApi.Modules.Logging
{
    public static class WatchDogExtensions
    {
        public static IServiceCollection AddWatchDogModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddWatchDogServices(opt =>
            {
                //conectar a una bd diferente a la de la app
                opt.SetExternalDbConnString = configuration.GetConnectionString("NorthwindConnection");
                opt.DbDriverOption = WatchDog.src.Enums.WatchDogDbDriverEnum.MSSQL;
                opt.IsAutoClear = true;
                opt.ClearTimeSchedule = WatchDog.src.Enums.WatchDogAutoClearScheduleEnum.Monthly;
            });

            return services;
        }
    }
}
