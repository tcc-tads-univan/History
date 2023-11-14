using System.Text.Json.Serialization;

namespace History.Api.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserType
    {
        STUDENT = 1,
        DRIVER = 2
    }
}
