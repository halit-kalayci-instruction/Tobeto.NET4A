using Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.AspNetCore.Http;
using System.Text.Json;


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
                await _next(context); // herhangi bir işlem
            }
            catch(Exception exception)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                if (exception is BusinessException)
                {
                    ProblemDetails problemDetails = new ProblemDetails();
                    problemDetails.Title = "Business Rule Violation";
                    problemDetails.Detail = exception.Message;
                    problemDetails.Type = "BusinessException";
                    await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
                }
                else if(exception is ValidationException)
                {

                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await context.Response.WriteAsync("Bilinmedik Hata");
                }

            }
        }
    }
}
