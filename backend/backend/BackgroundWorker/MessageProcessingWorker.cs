using System.Text.Json;
using backend.Dto;
using backend.Repository;
using backend.Repository.Interfaces;
using backend.Transport;

namespace backend.BackgroundWorker;

public class MessageProcessingWorker  : BackgroundService
{
    private readonly MessageStorageQueue _queue;
    private readonly IServiceProvider _serviceProvider;
    private readonly NeuralClient _neuralClient;
    private Dictionary<Guid, int> _expectedResponses;

    public MessageProcessingWorker(MessageStorageQueue queue, IServiceProvider serviceProvider, NeuralClient neuralClient)
    {
        _queue = queue;
        _serviceProvider = serviceProvider;
        _neuralClient = neuralClient;
        _expectedResponses = new Dictionary<Guid, int>();
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var messagesBufferRepository = scope.ServiceProvider.GetRequiredService<IMessagesBufferRepository>();
        var message = await _queue.GetMessageAsync(stoppingToken);
        await messagesBufferRepository.CreateAsync(message);
        
        if (await messagesBufferRepository.GetCountAsync() >= 500) {
            await SendMessagesToNeuralAsync(messagesBufferRepository);
            await messagesBufferRepository.ClearAsync();
        }
    }
    
     private async Task SendMessagesToNeuralAsync(IMessagesBufferRepository messagesBufferRepository) {
        var messages = await messagesBufferRepository.GetAllAsync();
        await _neuralClient.PostAsync(messages);
     }
}