using backend.Entities;

namespace backend.Repository.Interfaces;

public interface IMessageRepository
{
    public Task<Message> CreateAsync(Message message);
    public Task<ICollection<Message>> GetAllByUserIdAsync(int userId);
    public Task<bool> DeleteAsync(int messageId);
}