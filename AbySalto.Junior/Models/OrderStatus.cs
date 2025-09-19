using System.Text.Json.Serialization;

namespace AbySalto.Junior.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OrderStatus
    {
        Pending = 0,
        InProgress = 1,
        Completed = 2,
    }
}
