using Microsoft.AspNetCore.Http;

namespace Spareparts.API.Middlewares; 
public class ErrorHandlingMiddle : IMiddleware {
    public async Task InvokeAsync(HttpContext context, RequestDelegate next) {
        try {
            await next.Invoke(context);
        }catch(Exception ex) {

            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(new ErrorMessage {
                StatusCode = 500,
                Message = ex.Message
            }.ToString());
        }
    }
}
