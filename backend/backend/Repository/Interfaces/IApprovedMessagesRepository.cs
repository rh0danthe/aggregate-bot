using backend.Entities;

namespace backend.Repository.Interfaces;

public interface IApprovedMessagesRepository
{
    public Task<ApprovedMessage> CreateAsync(ApprovedMessage message);
    public Task<ICollection<ApprovedMessage>> GetAllByQueryAsync(string[] keywords, string sessionString);
}