using ArquitecturaAppEmpresariales.Ecommerce.Transversal.Mapper;
using AutoMapper;

namespace ArquitecturaAppEmpresariales.Ecommerce.Services.WebApi.Modules.Mapper
{
    public static class MapperExtensions
    {
        public static IServiceCollection AddMapperModule(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingsProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
