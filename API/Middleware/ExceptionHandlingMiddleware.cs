using System.Net;
using System.Text.Json;
using Application.DTOs;
using Domain.Exceptions;


namespace ArchitectureTestApp.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    private static readonly ErrorCode UnknownError;
    private static readonly int DefaultHttpStatus;
    private static readonly string DefaultMessage;

    static ExceptionHandlingMiddleware()
    {
        UnknownError = ErrorCode.UNKNOWN_ERROR;
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
            _logger.LogError($"An unhandled exception occurred: {ex.Message}.");

            if (ex.InnerException != null)
            {
                _logger.LogError(ex.InnerException, "Inner exception details.");
            }

            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var (statusCode, errorCode, message) = MapException(exception);

        // Include stack trace only in development
        var environment = context.RequestServices.GetService<IWebHostEnvironment>();
        var stackTrace = environment?.IsDevelopment() == true ? exception.StackTrace : null;

        var response = new ErrorResponseDTO(message, errorCode, stackTrace);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        return JsonSerializer.SerializeAsync(context.Response.Body, response, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
    }

    private static (int StatusCode,  ErrorCode, string message) MapException(Exception exception)
    {
        return exception switch
        {
            GlobalException ge => ((int)ge.StatusCode, ge.ErrorCode, ge.Message),
            ArgumentException => ((int)HttpStatusCode.BadRequest, ErrorCode.ARGUMENT_ERROR, "Invalid argument."),
            UnauthorizedAccessException => ((int)HttpStatusCode.Unauthorized, ErrorCode.UNAUTHORIZED, "Access denied."),
            _ => (DefaultHttpStatus, UnknownError, DefaultMessage)
        };
    }
}
