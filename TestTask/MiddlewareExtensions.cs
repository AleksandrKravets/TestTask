using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using TestTask.Infrastructure.Middleware;

namespace TestTask
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseLongRequestsHandler(this IApplicationBuilder builder, IConfiguration configuration)
        {
            int millisecondsPerRequest = int.Parse(configuration["MiddlewareSettings:RequestDuration"]);
            builder.UseMiddleware<LongRequestsHandler>(millisecondsPerRequest);

            return builder;
        }
    }
}
