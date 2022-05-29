using BilgeAdam.Api.Contracts;
using BilgeAdam.Api.Middlewares;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace BilgeAdam.Api.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void UseRequestIdentity(this WebApplication app)
        {
            app.UseMiddleware<RequestIdentityMiddleware>();
        }

        public static void UseCustomException(this WebApplication app)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var exceptionFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    var requestIdentity = context.RequestServices.GetRequiredService<RequestIdentity>();
                    var logger = context.RequestServices.GetRequiredService<ILogger<RequestIdentity>>();
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await context.Response.WriteAsync($"Bir hata oluştu. Sistem yöneticisine aşağıdaki kimlik numarası ile erişebilirsiniz : {requestIdentity.Id}");
                    logger.LogError(exceptionFeature.Error.Message);
                });
            });
        }
    }
}
