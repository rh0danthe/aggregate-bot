namespace backend.Dto;

public class ApprovedMessageResponse
{
    public string Title { get; set; }
    public int ChatId { get; set; }
    public int MessageId { get; set; }
    public string SessionString { get; set; }
    public string Content { get; set; }
}