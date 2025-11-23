using netCoreApi.Services;

namespace netCoreApi.Extensions
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            services.AddScoped<UserService>();

            return services;
        }
    }
}
