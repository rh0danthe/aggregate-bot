namespace backend.Dto;

public class NeuralRequest
{
    public bool IsFound { get; set; }
    public string SessionString { get; set; }
    public string[] Keywords { get; set; }
    public ICollection<ApprovedMessageRequest> Messages { get; set; }
}