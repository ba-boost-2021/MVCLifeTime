using BilgeAdam.Common.Contracts;

namespace BilgeAdam.Api.Middlewares
{
    public class RegionalSeparationMiddleware
    {
        private readonly RequestDelegate next;
        public RegionalSeparationMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, RegionalParameters regionalParameters)
        {
            if(httpContext.Request.Headers.TryGetValue("region", out var header))
            {
                regionalParameters.Setup(header);
            }
            await next(httpContext);
        }
    }
}
