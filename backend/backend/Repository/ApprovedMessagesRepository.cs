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
        var query = "INSERT INTO \"ApprovedMessages\" (\"Content\", \"Title\", \"SessionString\", \"ChatId\", " +
                    "\"MessageId\", \"IsFound\") VALUES(@Content, @Title, @SessionString, @ChatId, " +
                    "@MessageId, @IsFound) RETURNING *";
        return await connection.QueryFirstOrDefaultAsync<ApprovedMessage>(query, message);
    }

    public async Task<ICollection<ApprovedMessage>> GetAllByQueryAsync(string[] keywords, string sessionString)
    {
        using var connection = await _factory.CreateAsync();

        var inParameters = string.Join(",", keywords.Select((_, index) => $"@key{index}"));

        var parameters = new DynamicParameters();
        for (int i = 0; i < keywords.Length; i++)
        {
            parameters.Add($"key{i}", keywords[i]);
        }

        parameters.Add("sessionString", sessionString);

        var sqlQuery =
            $"SELECT * FROM \"ApprovedMessages\" WHERE \"Title\" IN ({inParameters}) AND \"SessionString\" = @sessionString";

        var messages = await connection.QueryAsync<ApprovedMessage>(sqlQuery, parameters);
        return messages.ToList();

    }
}