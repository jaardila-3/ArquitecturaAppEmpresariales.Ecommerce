using ArquitecturaAppEmpresariales.Application.Validator;

namespace ArquitecturaAppEmpresariales.Ecommerce.Services.WebApi.Modules.Validator
{
    public static class ValidatorExtensions
    {
        public static IServiceCollection AddValidatorModule(this IServiceCollection services)
        {            
            services.AddTransient<UsersDtoValidator>();
            return services;
        }
    }
}
