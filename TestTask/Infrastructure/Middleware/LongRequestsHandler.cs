using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TestTask.Infrastructure.Middleware
{
    public class LongRequestsHandler
    {
        private readonly RequestDelegate _next;
        private readonly int _millisecondsPerRequest;

        public LongRequestsHandler(RequestDelegate next, int millisecondsPerRequest)
        {
            this._next = next;
            this._millisecondsPerRequest = millisecondsPerRequest;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var task = _next.Invoke(context);

            if (await Task.WhenAny(task, Task.Delay(_millisecondsPerRequest)) != task)
            {
                context.Response.StatusCode = 504;
            }
        }
    }
}
