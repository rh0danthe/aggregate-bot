using backend.Entities;
using backend.Factories.Interfaces;
using backend.Repository.Interfaces;
using Dapper;

namespace backend.Repository;

public class MessageRepository : IMessageRepository
{
    private readonly IDbConnectionFactory _factory;
    
    public MessageRepository(IDbConnectionFactory factory)
    {
        _factory = factory;
    }
    
    public async Task<Message> CreateAsync(Message message)
    {
        using var connection = await _factory.CreateAsync();
        var query = "INSERT INTO \"Messages\" (\"Content\", \"UserId\") VALUES(@Content, @UserId) RETURNING *";
        return await connection.QueryFirstOrDefaultAsync<Message>(query, message);
    }

    public async Task<ICollection<Message>> GetAllByUserIdAsync(int userId)
    {
        using var connection = await _factory.CreateAsync();
        var messages = await connection.QueryAsync<Message>("SELECT * FROM \"Messages\" WHERE \"UserId\" = @UserId", new {UserId = userId});
        return messages.ToList();
    }

    public async Task<bool> DeleteAsync(int messageId)
    {
        using var connection = await _factory.CreateAsync();
        var query = "DELETE FROM \"Messages\" WHERE \"Id\" = @id";
        var res = await connection.ExecuteAsync(query, new { id = messageId });
        return res > 0;
    }
}