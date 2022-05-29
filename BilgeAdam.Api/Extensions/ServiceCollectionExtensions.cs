using BilgeAdam.Api.Contracts;

namespace BilgeAdam.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRequestIdentity(this IServiceCollection services)
        {
            services.AddScoped<RequestIdentity>();
        }
    }
}
