using System.Collections.Concurrent;
using backend.Dto;
using backend.Entities;

namespace backend.BackgroundWorker;

public class MessageStorageQueue
{
    private readonly ConcurrentQueue<Message> _queue = new();
    private SemaphoreSlim _signal = new SemaphoreSlim(0);

    public void AddMessage(Message message)
    {
        _queue.Enqueue(message);
        _signal.Release();
    }
    
    public async Task<Message> GetMessageAsync(CancellationToken cancellationToken)
    {
        await _signal.WaitAsync(cancellationToken);
        _queue.TryDequeue(out var message);
        return message;
    }
}