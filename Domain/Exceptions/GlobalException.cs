using System.Net;

namespace Domain.Exceptions;

using System;
using System.Net;

public class GlobalException : Exception
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorCode { get; }

    public GlobalException(string message, HttpStatusCode statusCode, string errorCode)
        : base(message) 
    {
        StatusCode = statusCode;
        ErrorCode = errorCode;
    }

    public GlobalException(string message, HttpStatusCode statusCode, string errorCode, Exception innerException)
        : base(message, innerException)
    {
        StatusCode = statusCode;
        ErrorCode = errorCode;
    }
    
}
