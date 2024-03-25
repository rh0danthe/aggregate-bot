namespace backend.Entities;

public class ApprovedMessage
{
    public int Id { get; set; }
    public int UserId  { get; set; }
    public string Title { get; set; }
    public bool IsFound { get; set; }
    public long ChatId { get; set; }
    public long MessageId { get; set; }
    public string Content { get; set; }
    
    public string SenderName { get; set; }
    
    public string SenderContacts { get; set; }
    
    public string ChatName { get; set; }
}