using Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.AspNetCore.Http;


namespace Core.CrossCuttingConcerns.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception exception)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                string errorMessage;
                if (exception is BusinessException)
                {
                    errorMessage = exception.Message;
                }
                else
                {
                    errorMessage = "Bilinmedik Hata";
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                }
                await context.Response.WriteAsync(errorMessage);

            }
        }
    }
}
