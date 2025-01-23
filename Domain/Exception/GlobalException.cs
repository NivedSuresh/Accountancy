using System.Net;

namespace Domain.Exceptions;

using System;
using System.Net;

public class GlobalException : Exception
{
    public HttpStatusCode StatusCode { get; }
    public ErrorCode ErrorCode { get; }

    public GlobalException(string message, HttpStatusCode statusCode, ErrorCode errorCode)
        : base(message) 
    {
        StatusCode = statusCode;
        ErrorCode = errorCode;
    }

    public GlobalException(string message, HttpStatusCode statusCode, ErrorCode errorCode, Exception innerException)
        : base(message, innerException)
    {
        StatusCode = statusCode;
        ErrorCode = errorCode;
    }
    
}
