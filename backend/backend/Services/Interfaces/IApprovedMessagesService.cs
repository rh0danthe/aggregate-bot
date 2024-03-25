using backend.Dto;

namespace backend.Services.Interfaces;

public interface IApprovedMessagesService
{
    public Task<ICollection<Msg>> CreateAsync(ICollection<ApprovedMessageRequest> messages, bool isFound, int userId);
    public Task<ICollection<Msg>> GetAllByKeywordsAsync(string[] keywords, int userId);
}