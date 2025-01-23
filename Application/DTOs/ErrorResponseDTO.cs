
using Domain.Exceptions;

namespace Application.DTOs;

public struct ErrorResponseDTO
{
    public string Message { set; get; }
    public ErrorCode ErrorCode { set; get; }
    public string? StackTrace { set; get; }
    

    public ErrorResponseDTO(string Message, ErrorCode ErrorCode, string? StackTrace)
    {
        this.Message = Message;
        this.ErrorCode = ErrorCode;
        this.StackTrace = StackTrace;
    }
}