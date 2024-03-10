namespace backend.Entities;

public class ApprovedMessage
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Query { get; set; }
    public string Content { get; set; }
}