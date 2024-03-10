namespace backend.Dto;

public class ApprovedMessageResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Query { get; set; }
    public string Content { get; set; }
}