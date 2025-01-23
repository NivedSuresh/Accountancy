using System.Text.Json.Serialization;

namespace Domain.Exceptions;


[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ErrorCode {
    INVALID_PAYLOAD,
    UNAUTHORIZED,
    ARGUMENT_ERROR,
    UNKNOWN_ERROR
}