using backend.Entities;
using backend.Factories.Interfaces;
using backend.Repository.Interfaces;
using Dapper;

namespace backend.Repository;

public class ApprovedMessagesRepository : IApprovedMessagesRepository
{
    private readonly IDbConnectionFactory _factory;
    
    public ApprovedMessagesRepository(IDbConnectionFactory factory)
    {
        _factory = factory;
    }
    
    public async Task<ApprovedMessage> CreateAsync(ApprovedMessage message)
    {
        using var connection = await _factory.CreateAsync();
        var query = "INSERT INTO \"ApprovedMessages\" (\"Content\", \"UserId\", \"Query\") VALUES(@Content, @UserId, @Query) RETURNING *";
        return await connection.QueryFirstOrDefaultAsync<ApprovedMessage>(query, message);
    }

    public async Task<ICollection<ApprovedMessage>> GetAllByQueryAsync(string query)
    {
        using var connection = await _factory.CreateAsync();
        var messages = await connection.QueryAsync<ApprovedMessage>("SELECT * FROM \"ApprovedMessages\" WHERE \"Query\" = @Query", new {Query = query});
        return messages.ToList();
    }
}