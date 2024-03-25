using System.Text.Json.Serialization;

namespace backend.Dto;

public class NeuralRequest
{
    [JsonPropertyName("is_found")]
    public bool is_found { get; set; }
    
    [JsonPropertyName("session")]
    public string session { get; set; }
    
    [JsonPropertyName("keywords")]
    public string[] keywords { get; set; }
    
    [JsonPropertyName("msgs")]
    public ICollection<ApprovedMessageRequest> msgs { get; set; }
}