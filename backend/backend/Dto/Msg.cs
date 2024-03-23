using System.Text.Json.Serialization;

namespace backend.Dto;

public class Response
{
    [JsonPropertyName("title")]
    public string Title { get; set; }
    
    [JsonPropertyName("chat_id")]
    public long ChatId { get; set; }
    
    [JsonPropertyName("msg_id")]
    public long MessageId { get; set; }
    
    [JsonPropertyName("session_string")]
    public string SessionString { get; set; }
    
    [JsonPropertyName("text")]
    public string Text { get; set; }
}