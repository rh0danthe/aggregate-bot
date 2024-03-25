using System.Text.Json.Serialization;

namespace backend.Dto;

public class Msg
{
    [JsonPropertyName("title")]
    public string Title { get; set; }
    
    [JsonPropertyName("chat_id")]
    public long ChatId { get; set; }
    
    [JsonPropertyName("msg_id")]
    public long MessageId { get; set; }
    
    [JsonPropertyName("text")]
    public string Content { get; set; }
    
    [JsonPropertyName("sender_name")]
    public string SenderName { get; set; }
    
    [JsonPropertyName("sender_contacts")]
    public string SenderContacts { get; set; }
    
    [JsonPropertyName("chatName")]
    public string ChatName { get; set; }
}