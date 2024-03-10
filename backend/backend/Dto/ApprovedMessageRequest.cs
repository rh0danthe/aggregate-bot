namespace backend.Dto;

public class ApprovedMessageRequest
{
    public int UserId { get; set; }
    public string Query { get; set; }
    public string Content { get; set; }
}