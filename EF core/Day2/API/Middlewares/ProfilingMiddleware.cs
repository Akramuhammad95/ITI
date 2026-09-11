using System.Diagnostics;

namespace API.Middlewares
{
    public class ProfilingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ProfilingMiddleware> logger;

        //public delegate Task RequestDelegate(HttpContext context);


        public ProfilingMiddleware(RequestDelegate next, ILogger<ProfilingMiddleware> logger)
        {
            _next = next;
            this.logger = logger;
        }

        
        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();
            await _next(context);
            stopwatch.Stop();
            var elapsedTime = stopwatch.ElapsedMilliseconds;
            logger.LogInformation("Request to {Path} took {ElapsedTime} ms", context.Request.Path, elapsedTime);

        }
    }
}
