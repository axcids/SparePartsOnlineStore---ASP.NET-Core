using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Spareparts.API.Middlewares; 
public class ErrorHandlingMiddle : IMiddleware {
    public async Task InvokeAsync(HttpContext context, RequestDelegate next) {
        try {
            await next.Invoke(context);
        }catch(Exception ex) {

            context.Response.ContentType = "application/json";
            var error = new ErrorMessage {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message,
            };

            var json = JsonSerializer.Serialize(error);
            await context.Response.WriteAsync(json);
        }
    }
}
