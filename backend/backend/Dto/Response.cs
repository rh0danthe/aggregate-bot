using System.Text.Json.Serialization;

namespace backend.Dto;

public class Request
{
    [JsonPropertyName("msgs")]
    public ICollection<Msg> Messages { get; set; }
}