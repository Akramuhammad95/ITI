using System.Net;
using System.Text.Json;
using Microsoft.Data.SqlClient;

namespace API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Exception GetRealException(Exception ex)
        {
            while (ex.InnerException != null)
                ex = ex.InnerException;

            return ex;
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            ex = GetRealException(ex);

            _logger.LogError(ex, ex.Message);

            context.Response.ContentType = "application/json";

            context.Response.StatusCode = ex switch
            {
                KeyNotFoundException => StatusCodes.Status404NotFound,
                ArgumentException => StatusCodes.Status400BadRequest,
                SqlException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };

            var response = new
            {
                success = false,
                message = ex.Message,
                type = ex.GetType().Name,
                statusCode = context.Response.StatusCode
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}