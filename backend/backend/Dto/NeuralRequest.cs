using System.Text.Json.Serialization;

namespace backend.Dto;

public class NeuralRequest
{
    [JsonPropertyName("msgs")]
    public ICollection<Msg> Messages { get; set; }
}