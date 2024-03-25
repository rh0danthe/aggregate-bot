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
        var query = "INSERT INTO \"Users\" (\"SessionString\", \"TgId\", \"Name\") " +
                    "VALUES(@SessionString, @TgId, @Name) RETURNING *";
        return await connection.QueryFirstOrDefaultAsync<User>(query, user);
    }
}
