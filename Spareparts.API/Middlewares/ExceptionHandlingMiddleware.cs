using Microsoft.AspNetCore.Http;
using Spareparts.Application.Cars.Commands.CreateCar;
using System.Text.Json;

namespace Spareparts.API.Middlewares; 
public class ExceptionHandlingMiddleware : IMiddleware {
    public async Task InvokeAsync(HttpContext context, RequestDelegate next) {
        try {
            await next.Invoke(context);
        }catch(Exception ex) {
            context.Response.ContentType = "application/json";
            var error = new ExceptionMessage {
                Title = "An Exception occurred while processing your request.",
                StatusCode = context.Response.StatusCode,
                Message = ex.Message,
            };
            var json = JsonSerializer.Serialize(error);
            //await context.Response.WriteAsync("Something Went Wrong!");
            await context.Response.WriteAsync(json);
        }
    }
}
