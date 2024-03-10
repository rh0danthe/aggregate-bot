using System.Data;

namespace backend.Factories.Interfaces;

public interface IDbConnectionFactory
{
    Task<IDbConnection> CreateAsync();
}