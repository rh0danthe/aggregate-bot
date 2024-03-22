using System.Reflection;
using backend.BackgroundWorker;
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

builder.Services.AddSingleton<MessageStorageQueue>();
builder.Services.AddHostedService<MessageProcessingWorker>();

builder.Services.AddSingleton<IDbConnectionFactory, DefaultDbConnectionFactory>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IMessagesBufferRepository, MessagesBufferRepository>();
builder.Services.AddScoped<IApprovedMessagesRepository, ApprovedMessagesRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IApprovedMessagesService, ApprovedMessagesService>();

builder.Services.AddScoped<ExceptionMiddleware>();

builder.Services.AddSingleton<NeuralClient>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.Migrate<Program>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();