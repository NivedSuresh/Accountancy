using System.Net;
using System.Text.Json;
using Domain.Exceptions;


namespace ArchitectureTestApp.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    private static readonly string UnknownError;
    private static readonly int DefaultHttpStatus;
    private static readonly string DefaultMessage;

    static ExceptionHandlingMiddleware()
    {
        UnknownError = "UNKNOWN_ERROR";
        DefaultHttpStatus = (int) HttpStatusCode.InternalServerError;
        DefaultMessage = "An Unknown Error has occurred.";
    }

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context); // Pass the request to the next middleware
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred.");

            if (ex.InnerException != null)
            {
                _logger.LogError(ex.InnerException, "Inner exception details.");
            }

            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var (statusCode, errorCode) = MapException(exception);

        // Include stack trace only in development
        var environment = context.RequestServices.GetService<IWebHostEnvironment>();
        var stackTrace = environment?.IsDevelopment() == true ? exception.StackTrace : null;

        var response = new
        {
            Message = exception.Message ?? DefaultMessage,
            ErrorCode = errorCode,
            StackTrace = stackTrace
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;
        context.Response.Headers["X-Error-Code"] = errorCode;

        return JsonSerializer.SerializeAsync(context.Response.Body, response, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
    }

    private static (int StatusCode, string ErrorCode) MapException(Exception exception)
    {
        return exception switch
        {
            GlobalException ge => ((int)ge.StatusCode, ge.ErrorCode),
            ArgumentException => ((int)HttpStatusCode.BadRequest, "ARGUMENT_ERROR"),
            UnauthorizedAccessException => ((int)HttpStatusCode.Unauthorized, "UNAUTHORIZED"),
            _ => (DefaultHttpStatus, UnknownError)
        };
    }
}
