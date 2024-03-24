using System.Text.Json.Serialization;

namespace backend.Dto;

public class BotResponse
{
    
    [JsonPropertyName("session_string")]
    public string SessionString { get; set; }
    
    [JsonPropertyName("msgs")]
    public ICollection<Msg> Messages { get; set; }
    
}