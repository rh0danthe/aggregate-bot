using backend.Entities;
using backend.Factories.Interfaces;
using backend.Repository.Interfaces;
using Dapper;

namespace backend.Repository;

public class MessagesBufferRepository : IMessagesBufferRepository
{
    private readonly IDbConnectionFactory _factory;
    
    public MessagesBufferRepository(IDbConnectionFactory factory)
    {
        _factory = factory;
    }
    
    public async Task<Message> CreateAsync(Message message)
    {
        using var connection = await _factory.CreateAsync();
        var query = "INSERT INTO \"MessagesBuffer\" (\"Content\", \"UserId\") VALUES(@Content, @UserId) RETURNING *";
        return await connection.QueryFirstOrDefaultAsync<Message>(query, message);
    }

    public async Task<ICollection<Message>> GetAllAsync()
    {
        using var connection = await _factory.CreateAsync();
        var messages = await connection.QueryAsync<Message>("SELECT * FROM \"MessagesBuffer\"");
        return messages.ToList();
    }

    public async Task<int> GetCountAsync()
    {
        using var connection = await _factory.CreateAsync();
        return await connection.ExecuteScalarAsync<int>("SELECT COUNT(*)  FROM \"MessagesBuffer\"");
    }

    public async Task<bool> DeleteAsync(int messageId)
    {
        using var connection = await _factory.CreateAsync();
        var query = "DELETE FROM \"MessagesBuffer\" WHERE \"Id\" = @id";
        var res = await connection.ExecuteAsync(query, new { id = messageId });
        return res > 0;
    }

    public async Task<bool> ClearAsync()
    {
        using var connection = await _factory.CreateAsync();
        return (await connection.ExecuteAsync("DELETE FROM \"MessagesBuffer\"")) > 0;
    }
}