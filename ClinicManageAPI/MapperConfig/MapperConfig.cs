using Microsoft.Extensions.DependencyInjection;

namespace ClinicManageAPI.MapperConfig
{
    public static class MapperConfig
    {
        public static void AddMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ClinicManageProfile).Assembly);
        }
    }
}
