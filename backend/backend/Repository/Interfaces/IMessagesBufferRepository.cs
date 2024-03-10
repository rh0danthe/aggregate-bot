using backend.Entities;

namespace backend.Repository.Interfaces;

public interface IMessagesBufferRepository
{
    public Task<Message> CreateAsync(Message message);
    public Task<ICollection<Message>> GetAllAsync();
    public Task<int> GetCountAsync();
    public Task<bool> DeleteAsync(int messageId);
    public Task<bool> ClearAsync();
}