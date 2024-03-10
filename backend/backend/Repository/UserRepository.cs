using backend.Entities;
using backend.Factories.Interfaces;
using backend.Repository.Interfaces;
using Dapper;

namespace backend.Repository;

public class UserRepository : IUserRepository
{
    private readonly IDbConnectionFactory _factory;
    
    public UserRepository(IDbConnectionFactory factory)
    {
        _factory = factory;
    }
    
    public async Task<User> CreateAsync(User user)
    {
        using var connection = await _factory.CreateAsync();
        var query = "INSERT INTO \"Users\" (\"Query\", \"Token\") VALUES(@Query, @Token) RETURNING *";
        return await connection.QueryFirstOrDefaultAsync<User>(query, user);
    }

    public async Task<User> GetByIdAsync(int userId)
    {
        using var connection = await _factory.CreateAsync();
        var query = "SELECT * FROM \"Users\" WHERE \"Id\" = @Id";
        return await connection.QueryFirstOrDefaultAsync<User>(query, new {Id = userId});
    }
}