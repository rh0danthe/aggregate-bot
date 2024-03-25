using System.Text.Json.Serialization;

namespace backend.Dto;

public class ApprovedMessageRequest
{
    
    [JsonPropertyName("chat_id")]
    public long chat_id { get; set; }
    
    [JsonPropertyName("message_id")]
    public long message_id { get; set; }
    
    [JsonPropertyName("content")]
    public string content { get; set; }
    
    [JsonPropertyName("title")]
    public string title { get; set; }
    
    [JsonPropertyName("sender_name")]
    public string SenderName { get; set; }
    
    [JsonPropertyName("sender_contacts")]
    public string SenderContacts { get; set; }
    
    [JsonPropertyName("chatName")]
    public string ChatName { get; set; }
}