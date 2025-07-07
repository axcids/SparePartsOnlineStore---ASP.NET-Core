using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Spareparts.API.Middlewares;
internal sealed class GlobalExceptionHandler(IProblemDetailsService problemDetailsService) : IExceptionHandler {
    public ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken) {
        var problemDetails = exception switch {
            // Handle ArgumentException (bad request)
            ArgumentException argEx => new ProblemDetails {
                Status = StatusCodes.Status400BadRequest,
                Title = "Invalid Request",
                Detail = argEx.Message
            },

            // Handle other exceptions (internal server error)
            _ => new ProblemDetails {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Internal Server Error",
                Detail = "An error occurred while processing your request. Please try again."
            }
        };

        return problemDetailsService.TryWriteAsync(new ProblemDetailsContext {
            HttpContext = httpContext,
            Exception = exception,
            ProblemDetails = problemDetails
        });
    }
}
