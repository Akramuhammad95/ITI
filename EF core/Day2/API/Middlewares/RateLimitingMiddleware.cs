using System.Diagnostics;

namespace API.Middlewares
{
    public class RateLimitingMiddleware
    {
        private readonly RequestDelegate next;
        private static int _requestCounter = 0;
        private static DateTime _lastRequestDate=DateTime.Now;

        public RateLimitingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            _requestCounter++;
            

            if (_requestCounter > 10 && (DateTime.Now.Subtract(_lastRequestDate).Seconds < 10) )
            {
               
                    _requestCounter = 0;
                    _lastRequestDate = DateTime.Now;
                    await context.Response.WriteAsync("Rate limit exceeded");

            }
            else if (_requestCounter > 10)
                {
                    _requestCounter = 0;
                    _lastRequestDate = DateTime.Now;
                }


            await next(context);


        }
    }
}
