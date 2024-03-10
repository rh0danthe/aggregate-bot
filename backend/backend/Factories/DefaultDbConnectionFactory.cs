﻿using System.Data;
using backend.Factories.Interfaces;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace backend.Factories;

public class DefaultDbConnectionFactory : IDbConnectionFactory
{
    private readonly string _connectionString;
    
    public DefaultDbConnectionFactory(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string \"DefaultConnection\" has not been found.");
    }
    
    public async Task<IDbConnection> CreateAsync()
    {
        var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();
        return connection;
    }
}