using Microsoft.Extensions.DependencyInjection;

namespace BilgeAdam.Services
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddSingleton<SingletonService>();
            services.AddScoped<ScopedService>();
            services.AddTransient<TransientService>();
        }
    }
}