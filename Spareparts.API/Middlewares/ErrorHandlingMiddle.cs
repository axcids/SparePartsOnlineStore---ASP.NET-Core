using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Spareparts.API.Middlewares; 
public class ErrorHandlingMiddle : IMiddleware {
    public async Task InvokeAsync(HttpContext context, RequestDelegate next) {
        try {
            await next.Invoke(context);
        }catch(Exception ex) {

            context.Response.StatusCode = ex.HResult;
            context.Response.ContentType = "application/json";
            var error = new ErrorMessage {
                StatusCode = 500,
                Message = ex.Message,
                Details = ex.InnerException.ToString()
            };

            var json = JsonSerializer.Serialize(error);
            await context.Response.WriteAsync(json);
        }
    }
}
