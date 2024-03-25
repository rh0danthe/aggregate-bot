namespace backend.Entities;

public class User
{
    public int Id { get; set; }
    
    public long TgId { get; set; }
    
    public string Name { get; set; }
    public string SessionString { get; set; }
}