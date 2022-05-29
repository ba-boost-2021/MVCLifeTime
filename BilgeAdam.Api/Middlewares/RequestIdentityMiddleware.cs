using BilgeAdam.Api.Contracts;

namespace BilgeAdam.Api.Middlewares
{
    public class RequestIdentityMiddleware
    {
        private readonly RequestDelegate next;
        public RequestIdentityMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext, RequestIdentity requestIdentity, ILogger<RequestIdentityMiddleware> logger)
        {
            requestIdentity.Id = Guid.NewGuid();
            requestIdentity.TimeStamp = DateTime.Now;
            logger.LogInformation("İstek kimliği kazandırıldı");
            if (Random.Shared.Next(0, 37) % 29 != 0)
            {
                await next(httpContext);
            }
            else
            {
                logger.LogError("Rasgele değer isteğin sonlanmasına sebep oldu");
                httpContext.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                await httpContext.Response.WriteAsync("29 sayısı bize iyi gelmedi :(");
            }
        }
    }
}
