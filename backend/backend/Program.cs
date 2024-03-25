using System.Reflection;
using backend.Factories;
using backend.Factories.Interfaces;
using backend.Middleware;
using DbUp;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using backend.Migrations.Extensions;
using backend.Repository;
using backend.Repository.Interfaces;
using backend.Services;
using backend.Services.Interfaces;
using backend.Transport;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDbConnectionFactory, DefaultDbConnectionFactory>();

builder.Services.AddScoped<IApprovedMessagesRepository, ApprovedMessagesRepository>();

builder.Services.AddScoped<IApprovedMessagesService, ApprovedMessagesService>();

builder.Services.AddScoped<ExceptionMiddleware>();

builder.Services.AddSingleton<BotClient>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.Migrate<Program>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();