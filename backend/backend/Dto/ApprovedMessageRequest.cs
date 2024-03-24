namespace backend.Dto;

public class ApprovedMessageRequest
{
    public string Title { get; set; }
    public long ChatId { get; set; }
    public long MessageId { get; set; }
    public string Content { get; set; }
}